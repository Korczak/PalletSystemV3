using System.Threading.Tasks;

namespace PalletSystem.Core.SteeringLogic.Information
{
    public class SteeringLogicInformationDataAccess
    {
        public async Task<SteeringLogicStepInformation> GetStepInformation(int id)
        {
            //using (var db = new PalletDB())
            //{
            //    //var stepInformation = await db.VirtualPallets.LoadWith(x => x.Program)
            //    //    .Where(x => x.Id == id)
            //    //    .Select(x => new SteeringLogicStepInformation(x.StepId, x.Program.NumberOfSteps))
            //    //    .FirstOrDefaultAsync();

            //    return stepInformation;
            //}
            return null;
        }
    }
}
