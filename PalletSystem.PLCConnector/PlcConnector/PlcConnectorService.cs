using PalletSystem.PLCConnector.PlcConnector.Models;
using S7.Net;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
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
            while (numTries > 0 && !_plc.IsConnected)
            {
                try {
                    await _plc.OpenAsync();
                }
                catch(Exception ex)
                {
                    Log.Error(ex, "Could not connect to plc");
                }
            }

            if (!_plc.IsConnected)
            {
                Log.Error("Could not connect to plc");
            }
        }

        public async Task<PlcSourceData> PlcReadData()
        {
            var pcInformation = new PcModel();
            var plcInformation = new PlcModel();
            var pcResultsModel = new PcResultsModel();

            await Task.WhenAll(
                _plc.ReadClassAsync(pcInformation, 1),
                _plc.ReadClassAsync(plcInformation, 1, 54),
                _plc.ReadClassAsync(pcResultsModel, 1, 108));

            return new PlcSourceData(pcInformation, plcInformation, pcResultsModel);
        }
    }
}
