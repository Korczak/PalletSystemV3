using PalletSystem.PLCConnector.PlcConnector.Models;
using S7.Net;
using Serilog;
using System;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.PlcConnector
{
    public class PlcConnectorService : IConnectorService
    {
        private readonly Plc _plc;
        private readonly Config _config;
        public bool IsConnected => _plc.IsConnected;

        public PlcConnectorService(Config config)
        {
            _config = config;
            _plc = new Plc(CpuType.S71200, config.Ip, config.Rack, config.Slot);
        }

        public async Task Connect(int numTries = 30)
        {
            while (numTries > 0 && !_plc.IsConnected && !_plc.IsAvailable)
            {
                try
                {
                    await _plc.OpenAsync();
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Could not connect to plc");
                }
            }

            if (!_plc.IsConnected)
            {
                Log.Error("Could not connect to plc");
            }
            else
            {
                Log.Information("Plc is connected");
            }

            if (!_plc.IsAvailable)
            {
                Log.Error("Plc is unavailable");
            }
            else
            {
                Log.Information("Plc is available");
            }
        }

        public async Task<PlcSourceData> PlcReadData()
        {
            
            
            var pcInformation = new PcModel();
            var plcInformation = new PlcModel();

            var readed = _plc.Read(DataType.DataBlock, 1, 0, VarType.Int, 1);
            Log.Information("READ: " + readed);
            //await _plc.ReadClassAsync(pcInformation, 1);

            /*
            await Task.WhenAll(
                _plc.ReadClassAsync(pcInformation, 1),
                _plc.ReadClassAsync(plcInformation, 1, 44));
            */

            return new PlcSourceData(pcInformation, plcInformation);
        }
    }
}