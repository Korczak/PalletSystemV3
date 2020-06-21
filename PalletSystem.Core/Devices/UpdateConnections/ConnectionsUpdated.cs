using System.Collections.Generic;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class ConnectionsUpdated
    {
        public string ConnectorName { get; }
        public DeviceConnection NextSearching { get; }
        public IEnumerable<DeviceConnection> DisconnectedDevices { get; }
        public IEnumerable<DeviceConnection> ConnectedDevices { get; }

        public ConnectionsUpdated(
            string connectorName,
            DeviceConnection nextSearching,
            IEnumerable<DeviceConnection> disconnectedDevices,
            IEnumerable<DeviceConnection> connectedDevices)
        {
            ConnectorName = connectorName;
            NextSearching = nextSearching;
            DisconnectedDevices = disconnectedDevices;
            ConnectedDevices = connectedDevices;
        }

        public ConnectionsUpdated(
            string connectorName,
            IEnumerable<DeviceConnection> disconnectedDevices,
            IEnumerable<DeviceConnection> connectedDevices)
        {
            ConnectorName = connectorName;
            DisconnectedDevices = disconnectedDevices;
            ConnectedDevices = connectedDevices;
        }
    }
}