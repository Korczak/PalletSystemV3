using NodaTime;
using System.Net;

namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectorConnectProcessing
    {
        public ConnectorUpdated Updated { get; }
        public ConnectorAdded Added { get; }

        public ConnectorConnectProcessing(
            string existingConnectorId,
            string name,
            IPAddress address,
            Instant instant
            )
        {
            var addressString = GetIPAddressString(address);

            if (existingConnectorId != default)
            {
                Updated = new ConnectorUpdated(
                    existingConnectorId,
                    name,
                    addressString,
                    instant.InUtc().LocalDateTime);
            }
            else
            {
                Added = new ConnectorAdded(
                   name,
                   addressString,
                   instant.InUtc().LocalDateTime);
            }
        }

        private string GetIPAddressString(IPAddress ipAddress)
        {
            if (IPAddress.IsLoopback(ipAddress))
            {
                return IPAddress.Loopback.MapToIPv4().ToString();
            }
            else
            {
                return ipAddress.MapToIPv4().ToString();
            }
        }
    }
}
