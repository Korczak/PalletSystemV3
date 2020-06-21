using NodaTime;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectorService
    {
        private readonly SyncConnectorAccess _dataAccess;
        private readonly IClock _clock;

        public SyncConnectorService(SyncConnectorAccess dataAccess, IClock clock)
        {
            _dataAccess = dataAccess;
            _clock = clock;
        }

        public Task<SyncConnectorModel> SyncConnector(SyncConnectorRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return InternalSyncDeviceConnector(request);
        }

        private async Task<SyncConnectorModel> InternalSyncDeviceConnector(SyncConnectorRequest request)
        {
            var local = _clock.GetCurrentInstant().InUtc().LocalDateTime;
            var updated = new SyncConnectorUpdated(request.UniqueName, local);
            return await _dataAccess.RunSyncModel(updated);
        }
    }
}
