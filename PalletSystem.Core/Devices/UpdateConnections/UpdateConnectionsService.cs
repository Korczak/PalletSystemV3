using System;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class UpdateConnectionsService
    {
        private readonly UpdateConnectionsAccess _dataAccess;
        private readonly UpdateConnectionsHub _hub;

        public UpdateConnectionsService(
            UpdateConnectionsAccess dataAccess,
            UpdateConnectionsHub hub)
        {
            _dataAccess = dataAccess;
            _hub = hub;
        }

        public Task UpdateConnections(ConnectionsStatusRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            return InternalUpdateConnections(request);
        }

        private async Task InternalUpdateConnections(ConnectionsStatusRequest request)
        {
            var deviceIdsConnected = request.ConnectedDevices.Select(x => x.Id);
            var allDeviceIds = deviceIdsConnected.Union(request.DisconnectedDevices);
            var connections = await _dataAccess.GetConnections(allDeviceIds);
            var processing = new ConnectionUpdateProcessing(connections, request);
            if (processing.Result == null) return;
            await _dataAccess.UpdateDeviceConnections(processing.Result);
            await _hub.ConnectionUpdate();
        }
    }
}
