using NodaTime;

namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectorAdded
    {
        public string Name { get; }
        public string Address { get; }
        public LocalDateTime CurrentDateTime { get; }

        public ConnectorAdded(string name, string address, LocalDateTime currentDateTime)
        {
            Name = name;
            Address = address;
            CurrentDateTime = currentDateTime;
        }
    }
}
