namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectorConnectRequest
    {
        public string UniqueName { get; }

        public ConnectorConnectRequest(string uniqueName)
        {
            UniqueName = uniqueName;
        }
    }
}
