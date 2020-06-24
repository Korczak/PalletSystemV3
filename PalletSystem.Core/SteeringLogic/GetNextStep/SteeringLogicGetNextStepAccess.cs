using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic.GetNextStep
{
    public class SteeringLogicGetNextStepAccess
    {
        public async Task<SteeringLogicGetNextStepInformation> GetNextStep(string rfid)
        {
            using(var handler = new DatabaseHandler())
            {                   
                var programQuery = from pallet in handler.db.Pallets.AsQueryable()
                    where pallet.RFID == rfid
                    join virtualPallet in handler.db.VirtualPallets.AsQueryable() on pallet.Id equals virtualPallet.PalletId
                    where virtualPallet.IsActive == true
                    select new { virtualPallet.Program.ActiveStep, virtualPallet.Status, Instructions = virtualPallet.Program.ProgramStepsInstructions };


                var program = await programQuery.FirstOrDefaultAsync();

                var nextStep = program.Instructions
                    .Where(i => i.Step == program.ActiveStep)
                    .Select(i => new SteeringLogicGetNextStepInformation(i.OperationMask, program.Status, i.Command, i.Parameters))
                    .FirstOrDefault();

                return nextStep;
            }
        }
    }
}
