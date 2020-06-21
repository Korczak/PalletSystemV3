namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class DeviceConnection
    {
        public string Id { get; }
        public string Name { get; }

        public DeviceConnection(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
