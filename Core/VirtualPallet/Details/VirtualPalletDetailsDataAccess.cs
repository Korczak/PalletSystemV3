using Core.Program.Command;
using System.Linq;
using System.Threading.Tasks;

namespace Core.VirtualPallet.Details
{
    public class VirtualPalletDetailsDataAccess
    {
        public async Task<VirtualPalletDetails> GetVirtualPalletDetails(int id)
        {
            //using(var db = new PalletDB())
            //{
            //    var virtualPalletDetails = await db.VirtualPallets
            //        .LoadWith(x => x.Program)
            //        .LoadWith(x => x.Step)
            //        .Where(x => x.Id == id)
            //        .Select(x => new VirtualPalletDetails(
            //            x.Id,
            //            x.PalletId,
            //            x.ProgramId,
            //            x.Program.Name,
            //            x.StepId,
            //            x.Program.NumberOfSteps,
            //            new ProgramStepCommand(x.Step),
            //            x.Status))
            //        .FirstOrDefaultAsync();

            //    return virtualPalletDetails;
            //}
            return null;
        }
    }
}
