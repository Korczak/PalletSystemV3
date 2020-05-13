using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Pallet;
using PalletSystem.Core.Database.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Add
{
    public class PalletAddAccess
    {
        public async Task<ObjectId> GetExistingPallet(string RFID)
        {
            using (var handler = new DatabaseHandler())
            {
                return await handler.db.Pallets.AsQueryable()
                    .Where(x => x.RFID == RFID && !x.IsDelete)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task AddPallet(PalletAdded added)
        {
            using (var handler = new DatabaseHandler())
            {
                await handler.StartTransaction();
                try
                {
                    var palletToInsert = new Pallets()
                    {
                        RFID = added.RFID,
                        Status = Constant.PalletStatus.Ready
                    };
                    await handler.db.Pallets.InsertOneAsync(palletToInsert);
                    await handler.CommitTransaction();
                }
                catch
                {
                    await handler.AbortTransaction();
                }
            }
        }
    }
}
