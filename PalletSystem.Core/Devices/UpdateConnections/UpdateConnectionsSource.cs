using System.Collections.Generic;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class UpdateConnectionsSource
    {
        public List<DeviceConnection> DevicesAffected { get; }

        public UpdateConnectionsSource(List<DeviceConnection> devicesAffected)
        {
            DevicesAffected = devicesAffected;
        }
    }
}
