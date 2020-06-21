using NodaTime;

namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectorUpdated
    {
        public string Name { get; }
        public LocalDateTime CurrentDateTime { get; }

        public SyncConnectorUpdated(string name, LocalDateTime currentDateTime)
        {
            Name = name;
            CurrentDateTime = currentDateTime;
        }
    }
}
