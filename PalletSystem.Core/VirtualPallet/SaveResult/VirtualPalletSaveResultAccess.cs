using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Database.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletSaveResultAccess
    {
        public async Task<VirtualPalletSaveResultSource> GetVirtualPalletSource(string rfid)
        {
            using (var handler = new DatabaseHandler())
            {
                var palletQuery = from pallet in handler.db.Pallets.AsQueryable()
                                  where pallet.RFID == rfid
                                  join virtualPallet in handler.db.VirtualPallets.AsQueryable() on pallet.Id equals virtualPallet.PalletId
                                  where virtualPallet.IsActive == true
                                  select new VirtualPalletSaveResultSource(virtualPallet.Id, virtualPallet.Program.ActiveStep, virtualPallet.Program.ProgramStepsInstructions.Count());

                return await palletQuery.FirstOrDefaultAsync();
            }
        }

        public async Task SaveResults(ResultSaved saved)
        {
            using (var handler = new DatabaseHandler())
            {
                await handler.StartTransaction();
                try
                {

                    var instructionResultToInsert = new ProgramStepsHistories()
                    {
                        Step = saved.ActualStep,
                        Instant = saved.Instant,
                        OperationMask = saved.OperationMask,
                        Status = saved.ProgramStatus,
                        WorkspaceSlot = saved.WorkspaceSlot,
                        Results = saved.Results
                    };
                    await handler.db.VirtualPallets.UpdateOneAsync(
                        x => x.Id == saved.VirtualPalletId,
                        new UpdateDefinitionBuilder<VirtualPallets>()
                            .Push(v => v.Program.ProgramStepsHistories, instructionResultToInsert)
                            .Set(v => v.Program.ActiveStep, saved.ActualStep + 1)
                            .Set(v => v.Status, saved.VirtualPalletStatus));

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