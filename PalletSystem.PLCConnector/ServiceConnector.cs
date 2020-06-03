using EKFD.DeviceConnector.Client;
using S7.Net;
using S7.Net.Types;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector
{
    public class ServiceConnector : IDisposable
    {
        private System.Timers.Timer _timer; 
        private readonly SemaphoreSlim _connectToServerSemaphore = new SemaphoreSlim(1);
        private bool _isServerConnected;
        private Plc _plc; 
        private readonly ConnectorClient _webClient;

        public ServiceConnector(Config config, ConnectorClient client)
        {
            _plc = new Plc(CpuType.S71200, config.Ip, config.Rack, config.Slot);
            _webClient = client;
        }

        public void Start()
        {
            _plc.Open();
            _timer = new System.Timers.Timer()
            {
                AutoReset = true,
                Interval = 3000
            };
            _timer.Elapsed += SyncTimerTimeElapsed;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _plc.Close();
        }

        private void SyncTimerTimeElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(!_plc.IsConnected)
            {
                Log.Information("Trying to connect to plc...");
            }
        }
    }
}
