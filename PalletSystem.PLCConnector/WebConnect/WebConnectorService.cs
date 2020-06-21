using PalletSystem.PLCConnector.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.WebConnect
{
    public class WebConnectorService : IConnectorService
    {
        private readonly SemaphoreSlim _connectToServerSemaphore = new SemaphoreSlim(1);
        private readonly ConnectionManagement _connectionManagement;
        private Connector _connector { get; set; }
        private readonly ConnectorClient _webClient;
        private readonly Config _config;

        public bool IsConnected { get; private set; } = false;

        public WebConnectorService(Connector connector, ConnectorClient webClient, Config config)
        {
            _connectionManagement = new ConnectionManagement(webClient);
            _connector = connector;
            _webClient = webClient;
            _config = config;
        }

        public async Task ConnectToServer()
        {
            while (IsConnected != true)
            {
                if (await _connectToServerSemaphore.WaitAsync(0))
                {
                    try
                    {
                        var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault();
                        var phisical = networkInterface.GetPhysicalAddress();
                        var name = $"{Dns.GetHostName()}-{phisical.ToString()}";
                        await _webClient.ConnectConnectorAsync(new ConnectorConnectRequest() { UniqueName = name });
                        Log.Information("Connector: {name} Connected to server", _connector.Name);

                        IsConnected = true;
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Cannot connect to server");
                    }
                    finally
                    {
                        _connectToServerSemaphore.Release();
                    }
                }
            }
        }

    }
}
