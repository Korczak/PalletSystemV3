using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.Pallet;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Database.Settings;
using PalletSystem.Core.Pallet.Add;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRunAccess
    {
        public async Task<PalletSource> GetPalletSource(string id)
        {
            using (var handler = new DatabaseHandler())
            {
                return await handler.db.Pallets.AsQueryable()
                    .Where(x => x.Id == id)
                    .Select(x => new PalletSource(x.Id, x.Status))
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<string> GetProgramId(string id)
        {
            using (var handler = new DatabaseHandler())
            {
                return await handler.db.ProgramSchemes.AsQueryable()
                    .Where(x => x.Id == id)
                    .Select(x => x.Id)
                    .FirstOrDefaultAsync();
            }
        }

        public async Task<IEnumerable<ProgramStepsInstructions>> GetProgramInstructions(string id)
        {
            using (var handler = new DatabaseHandler())
            {
                var steps = await handler.db.ProgramSchemes.AsQueryable()
                    .Where(x => x.Id == id)
                    .Select(x => x.ProgramStepsInstructions)
                    .FirstOrDefaultAsync();

                return steps;
            }
        }

        public async Task RunPallet(PalletRun pallet)
        {
            using (var handler = new DatabaseHandler())
            {
                await handler.StartTransaction();
                try
                {
                    var palletToInsert = new VirtualPallets()
                    {
                        PalletId = pallet.PalletId,
                        Program = new Programs()
                        {
                            Id = pallet.ProgramId,
                            ActiveStep = 1,
                            ProgramStepsInstructions = pallet.Instructions
                        },
                        Status = VirtualPallet.Constants.VirtualPalletStatus.Running,
                        IsActive = true
                    };
                    await handler.db.VirtualPallets.InsertOneAsync(palletToInsert);
                    await handler.db.Pallets.UpdateOneAsync(
                        x => x.Id == pallet.PalletId,
                        new UpdateDefinitionBuilder<Pallets>()
                            .Set(x => x.Status, Constant.PalletStatus.Running));

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
