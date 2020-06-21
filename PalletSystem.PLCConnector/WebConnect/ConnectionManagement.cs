using PalletSystem.PLCConnector.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.PLCConnector.WebConnect
{
    public class ConnectionManagement
    {
        private readonly ConnectorClient _client;

        public ConnectionManagement(ConnectorClient client)
        {
            _client = client;
        }

        public async Task<SyncConnectorModel> LoadConfiguration(string hostName)
        {
            var request = new SyncConnectorRequest() { UniqueName = hostName };
            var response = await _client.PostSyncSignalAsync(request);

            return response;
        }

        public async Task SaveConfiguration(SyncConnectorModel connections)
        {

            var connected = connections.ConnectedDevices.Select(x => new DeviceConnect()
            {
                Connection = x.ConnectionUniqueName,
                Id = x.DeviceId
            })
                  .ToArray();

            var connectionsStatus = new ConnectionsStatusRequest()
            {
                ConnectorName = "TestName",
                ConnectedDevices = connected
            };

            await _client.UpdateConnectionsAsync(connectionsStatus);
        }
    }
}
