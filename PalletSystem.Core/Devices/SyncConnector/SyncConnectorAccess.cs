using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Connector;
using PalletSystem.Core.Database.Settings;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.SyncConnector
{
    public class SyncConnectorAccess
    {
        public async Task<SyncConnectorModel> RunSyncModel(SyncConnectorUpdated update)
        {
            using (var handler = new DatabaseHandler())
            {
                try
                {
                    await handler.StartTransaction();
                    var connectorId = await handler.db.Connectors.AsQueryable()
                        .Where(x => x.Name == update.Name)
                        .Select(x => x.Id)
                        .FirstOrDefaultAsync();

                    var connectedDevices = await handler.db.PLCs.AsQueryable()
                        .Where(x => x.ConnectorId == connectorId && x.ConnectionStatus == Pallet.Constant.ConnectionStatus.Connected)
                        .Select(x => new SyncConnectedDevice(x.Id, x.Name))
                        .ToListAsync();

                    await handler.db.Connectors.UpdateOneAsync(
                        x => x.Id == connectorId,
                        new UpdateDefinitionBuilder<Connector>()
                        .Set(x => x.Connected, true)
                        .Set(x => x.LastConnected, update.CurrentDateTime));

                    await handler.CommitTransaction();
                    return new SyncConnectorModel(connectedDevices);
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