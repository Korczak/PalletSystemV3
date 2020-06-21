using System.Collections.Generic;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class ConnectionsStatusRequest
    {
        public string ConnectorName { get; }
        public List<string> DisconnectedDevices { get; }
        public List<DeviceConnect> ConnectedDevices { get; }

        public ConnectionsStatusRequest(
            string connectorName,
            List<string> disconnectedDevices,
            List<DeviceConnect> connectedDevices)
        {
            ConnectorName = connectorName;
            DisconnectedDevices = disconnectedDevices;
            ConnectedDevices = connectedDevices;
        }
    }
}
