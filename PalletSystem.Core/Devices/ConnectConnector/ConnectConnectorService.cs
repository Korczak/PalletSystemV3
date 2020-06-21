using NodaTime;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectConnectorService
    {
        private readonly ConnectConnectorAccess _dataAccess;
        private readonly IClock _clock;

        public ConnectConnectorService(ConnectConnectorAccess dataAccess, IClock clock)
        {
            _dataAccess = dataAccess;
            _clock = clock;
        }

        public Task ConnectConnector(ConnectorConnectRequest request, IPAddress address)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            if (address == null) throw new ArgumentNullException(nameof(address));

            return InternalConnectConnector(request, address);
        }

        private async Task InternalConnectConnector(ConnectorConnectRequest request, IPAddress address)
        {
            var existingConnector = await _dataAccess.GetExistingConnectorIdByName(request.UniqueName);
            var result = new ConnectorConnectProcessing(
                existingConnector,
                request.UniqueName,
                address,
                _clock.GetCurrentInstant());

            if (result.Added != null)
            {
                await _dataAccess.AddConnector(result.Added);
            }
            else
            {
                await _dataAccess.UpdateConnector(result.Updated);
            }
        }
    }
}
