namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class DeviceConnect
    {
        public string Id { get; }
        public string Connection { get; }

        public DeviceConnect(string id, string connection)
        {
            Id = id;
            Connection = connection;
        }
    }
}
