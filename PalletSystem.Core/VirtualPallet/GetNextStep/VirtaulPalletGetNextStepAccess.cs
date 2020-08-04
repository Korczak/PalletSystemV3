using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class VirtualPalletGetNextStepAccess
    {
        public async Task<VirtualPalletGetNextStepSourceInformation> GetPalletInformation(string rfid)
        {
            using (var handler = new DatabaseHandler())
            {
                var palletQuery = from pallet in handler.db.Pallets.AsQueryable()
                                  where pallet.RFID == rfid
                                  join virtualPallet in handler.db.VirtualPallets.AsQueryable() on pallet.Id equals virtualPallet.PalletId
                                  where virtualPallet.IsActive == true
                                  select new VirtualPalletGetNextStepSourceInformation(virtualPallet.Id, virtualPallet.Status);

                return await palletQuery.FirstOrDefaultAsync();
            }
        }

        public async Task<NextStepInformation> GetNextStep(string rfid)
        {
            using (var handler = new DatabaseHandler())
            {
                var programQuery = from pallet in handler.db.Pallets.AsQueryable()
                                   where pallet.RFID == rfid
                                   join virtualPallet in handler.db.VirtualPallets.AsQueryable() on pallet.Id equals virtualPallet.PalletId
                                   where virtualPallet.IsActive == true
                                   select new { virtualPallet.Program.ActiveStep, virtualPallet.Status, Instructions = virtualPallet.Program.ProgramStepsInstructions };

                var program = await programQuery.FirstOrDefaultAsync();

                var nextStep = program.Instructions
                    .Where(i => i.Step == program.ActiveStep)
                    .Select(i => new NextStepInformation(i.OperationMask, program.Status, i.Command, i.Parameters))
                    .FirstOrDefault();

                return nextStep;
            }
        }
    }
}