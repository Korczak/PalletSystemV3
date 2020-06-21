namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectedDevice
    {
        public string DeviceId { get; }
        public string ConnectionUniqueName { get; }

        public SyncConnectedDevice(string deviceId, string connectionUniqueName)
        {
            DeviceId = deviceId;
            ConnectionUniqueName = connectionUniqueName;
        }
    }
}