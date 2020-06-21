using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Pallet;
using PalletSystem.Core.Database.Models.Plc;
using PalletSystem.Core.Database.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.Devices.UpdateConnections
{
    public class UpdateConnectionsAccess
    {
        public async Task UpdateDeviceConnections(ConnectionsUpdated connections)
        {
            using (var handler = new DatabaseHandler())
            {
                try
                {
                    await handler.StartTransaction();
                    var disconnected = connections.DisconnectedDevices.Select(x => x.Id).ToList();
                    var connected = connections.ConnectedDevices
                        .Select(x => new { x.Id }).ToList();

                    var connectorId = await handler.db.Connectors.AsQueryable()
                        .Where(x => x.Name == connections.ConnectorName)
                        .Select(x => x.Id)
                        .FirstOrDefaultAsync();

                    await handler.db.PLCs.UpdateOneAsync(
                        x => disconnected.Contains(x.Id),
                        new UpdateDefinitionBuilder<PLCs>()
                            .Set(x => x.ConnectionStatus, Pallet.Constant.ConnectionStatus.Disconnected));
                  
                    foreach (var connection in connected)
                    {
                        await handler.db.PLCs.UpdateOneAsync(
                        x => connection.Id == x.Id,
                        new UpdateDefinitionBuilder<PLCs>()
                            .Set(x => x.ConnectionStatus, Pallet.Constant.ConnectionStatus.Connected)
                            .Set(x => x.ConnectorId, connectorId));
                    }

                    await handler.CommitTransaction();
                }
                catch (Exception)
                {
                    await handler.AbortTransaction();
                    throw;
                }
            }
        }

        public async Task<UpdateConnectionsSource> GetConnections(IEnumerable<string> devices)
        {
            using (var handler = new DatabaseHandler())
            {
                var connections = await handler.db.PLCs.AsQueryable()
                    .Where(x => devices.Contains(x.Id))
                    .Select(x => new DeviceConnection(x.Id, x.Name))
                    .ToListAsync();
                return new UpdateConnectionsSource(connections);
            }
        }
    }
}
