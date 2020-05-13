using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic.CalculateStep
{
    public class SteeringLogicDataAccess
    {
        public async Task<SteeringLogicActualStep> GetActualtStep(int id)
        {
            //using(var db = new PalletDB())
            //{
            //    var actualStep = await db.VirtualPallets.LoadWith(x => x.Step)
            //        .Where(x => x.Id == id)
            //        .Select(x => new SteeringLogicActualStep(x.Id,new ProgramStepCommand(x.Step)))
            //        .FirstOrDefaultAsync();

            //    return actualStep;
            //}
            return null;
        }

        public async Task UpdateVirtualPallet(int virtualPalletId)
        {
            //using(var db = new PalletDB())
            //{
            //    //return SteeringLogicResponse.Success(virtualPalletId);
            //}
        }
    }
}
