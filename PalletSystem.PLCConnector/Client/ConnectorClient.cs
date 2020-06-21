using NodaTime;
using NodaTime.Serialization.JsonNet;


namespace PalletSystem.PLCConnector.Client
{
    public partial class ConnectorClient
    {
        partial void UpdateJsonSerializerSettings(Newtonsoft.Json.JsonSerializerSettings settings)
        {
            settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
        }

    }
}
