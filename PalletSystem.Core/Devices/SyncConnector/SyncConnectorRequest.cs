namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectorRequest
    {
        public string UniqueName { get; }

        public SyncConnectorRequest(string uniqueName)
        {
            UniqueName = uniqueName;
        }
    }
}
