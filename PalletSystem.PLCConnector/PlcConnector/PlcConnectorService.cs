using PalletSystem.PLCConnector.PlcConnector.Models;
using Serilog;
using Sharp7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.PlcConnector
{
    public class PlcConnectorService : IConnectorService
    {
        private readonly S7Client _client;
        private readonly Config _config;
        public bool IsConnected => _client.Connected;
        private readonly Station[] _stations;

        public PlcConnectorService(Config config)
        {
            _config = config;
            S7Client client = new S7Client();
            _stations = config.Stations.Split(',').Select(x => new Station(int.Parse(x))).ToArray();
        }

        public async Task Connect(int numTries = 30)
        {
            while (numTries > 0 && !_client.Connected)
            {
                try
                {
                    int ret = _client.ConnectTo(_config.Ip, 0, 0);
                    if (ret != 0) throw new Exception(_client.ErrorText(ret));
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Could not connect to plc");
                }
            }

            if (!_client.Connected)
            {
                Log.Error("Could not connect to plc");
            }
            else
            {
                Log.Information("Plc is connected");
            }
        }

        void Start()
        {

        }


        void Loop()
        {
            int index = 0;
            while (true)
            {
                _stations[index].Processing(_client);
                index = (index + 1) % _stations.Count();
            }
        }
    }
}