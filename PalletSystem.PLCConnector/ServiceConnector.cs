using PalletSystem.PLCConnector.Client;
using PalletSystem.PLCConnector.PlcConnector;
using PalletSystem.PLCConnector.WebConnect;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector
{
    public class ServiceConnector
    {
        private System.Timers.Timer _timer;
        private readonly SemaphoreSlim _connectToServerSemaphore = new SemaphoreSlim(1);
        private readonly ConnectorClient _webClient;
        private readonly WebConnectorService _webConnectorService;
        private readonly PlcConnectorService _plcConnectorService;
        private readonly Connector _connector;
        private readonly Config _config;

        public bool IsConnected { get; }

        public ServiceConnector(Connector connector, Config config, ConnectorClient client)
        {
            _webClient = client;
            _connector = connector;
            _config = config;
            _webConnectorService = new WebConnectorService(connector, client, config);
            _plcConnectorService = new PlcConnectorService(config);
            _timer = new System.Timers.Timer()
            {
                AutoReset = true,
                Interval = 5000
            };
            _timer.Elapsed += SyncTimerTimeElapsed;
        }

        public void Start()
        {
            var plcConnectTask = _plcConnectorService.Connect();
            var webConnectTask = _webConnectorService.ConnectToServer();

            Task.WaitAll(plcConnectTask, webConnectTask);
            if (!_plcConnectorService.IsConnected || !_webConnectorService.IsConnected)
            {
                Log.Error("Plc or Web is not connected");
                return;
            }
            else
            {
                _timer.Start();
            }
        }

        public void Stop()
        {
            _timer.Stop();
        }

        private void SyncTimerTimeElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            var results = _plcConnectorService.PlcReadData().GetAwaiter().GetResult();

            Log.Information($"Readed from PLC: PC: {results.PcModel}, PLC: {results.PlcModel}, Results: {results.PcResultsModel}");
        }
    }
}