using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Connector;
using PalletSystem.Core.Database.Settings;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.ConnectConnector
{
    public class ConnectConnectorAccess
    {
        public async Task<string> GetExistingConnectorIdByName(string name)
        {
            using (var handler = new DatabaseHandler())
            {
                var connector = await handler.db.Connectors.AsQueryable()
                    .Where(x => x.Name == name)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();
                return connector;
            }
        }

        public async Task UpdateConnector(ConnectorUpdated updateChange)
        {
            using (var handler = new DatabaseHandler())
            {
                try
                {
                    await handler.StartTransaction();
                    await handler.db.Connectors.UpdateOneAsync(
                        x => updateChange.Name == x.Name,
                        new UpdateDefinitionBuilder<Connector>()
                        .Set(x => x.Connected, true)
                        .Set(x => x.LastConnected, updateChange.CurrentDateTime));
                    await handler.CommitTransaction();
                }
                catch (Exception)
                {
                    await handler.AbortTransaction();
                    throw;
                }
            }
        }

        public async Task AddConnector(ConnectorAdded addChange)
        {
            using (var handler = new DatabaseHandler())
            {
                try
                {
                    await handler.StartTransaction();
                    var connector = new Connector()
                    {
                        Address = addChange.Address,
                        LastConnected = addChange.CurrentDateTime,
                        Name = addChange.Name,
                        Connected = true,
                    };
                    await handler.db.Connectors.InsertOneAsync(connector);
                    await handler.CommitTransaction();
                }
                catch (Exception)
                {
                    await handler.AbortTransaction();
                    throw;
                }
            }
        }
    }
}
