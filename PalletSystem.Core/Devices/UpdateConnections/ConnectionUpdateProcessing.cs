using System;
using System.Linq;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class ConnectionUpdateProcessing
    {
        public ConnectionsUpdated Result { get; }

        public ConnectionUpdateProcessing(
            UpdateConnectionsSource connections,
            ConnectionsStatusRequest statusChange)
        {
            if (connections == null) throw new ArgumentNullException(nameof(connections));
            if (statusChange == null) throw new ArgumentNullException(nameof(statusChange));
            if (connections.DevicesAffected.Count == 0) return;

            var disconnected = connections.DevicesAffected
                .Where(x => statusChange.DisconnectedDevices.Contains(x.Id));

            var connected = connections.DevicesAffected
                .Except(disconnected)
                .Select(x => {
                    return new DeviceConnection(x.Id, x.Name);
                });

             Result = new ConnectionsUpdated(statusChange.ConnectorName, disconnected, connected);
        }
    }
}
