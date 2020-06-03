using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Pallet;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Database.Settings;
using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Finish
{
    public class PalletFinishAccess
    {
        public async Task<PalletSource> GetPalletStatus(string id)
        {
            using (var handler = new DatabaseHandler())
            {
                return await handler.db.Pallets.AsQueryable().Where(x => x.Id == id).Select(x => new PalletSource(x.Id, x.Status)).FirstOrDefaultAsync();
            }
        }

        public async Task FinishPallet(PalletFinished pallet)
        {
            using (var handler = new DatabaseHandler())
            {
                try
                {
                    await handler.StartTransaction();
                    await handler.db.VirtualPallets.UpdateOneAsync(
                        x => x.PalletId == pallet.PalletId && x.IsActive,
                        new UpdateDefinitionBuilder<VirtualPallets>()
                            .Set(x => x.IsActive, false));

                    await handler.db.Pallets.UpdateOneAsync(
                        x => x.Id == pallet.PalletId,
                        new UpdateDefinitionBuilder<Pallets>()
                            .Set(x => x.Status, Constant.PalletStatus.Ready));

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
