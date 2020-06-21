using NodaTime;

namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectorUpdated
    {
        public string Id { get; }
        public string Name { get; }
        public string Address { get; }
        public LocalDateTime CurrentDateTime { get; }

        public ConnectorUpdated(string id, string name, string address, LocalDateTime currentDateTime)
        {
            Id = id;
            Name = name;
            Address = address;
            CurrentDateTime = currentDateTime;
        }
    }
}