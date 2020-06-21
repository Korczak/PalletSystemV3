using System.Collections.Generic;

namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectorModel
    {
        public List<SyncConnectedDevice> ConnectedDevices { get; }

        public SyncConnectorModel(List<SyncConnectedDevice> connectedDevices)
        {
            ConnectedDevices = connectedDevices;
        }
    }
}
