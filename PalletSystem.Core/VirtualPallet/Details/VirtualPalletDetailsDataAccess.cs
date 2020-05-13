using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletDetailsDataAccess
    {
        public async Task<VirtualPalletDetails> GetVirtualPalletDetails(string id)
        {
            using (var handler = new DatabaseHandler())
            {
                //var virtualPalletDetails = await handler.db.VirtualPallets.AsQueryable()
                //    .Where(x => x.Id == new ObjectId(id))
                //    .Select(x => new VirtualPalletDetails(
                //        x.Id.ToString(),
                //        x.PalletId.ToString(),
                //        x.ProgramId.ToString(),
                //        x.Program.Name,
                //        x.StepId,
                //        x.Program.NumberOfSteps,
                //        new ProgramStepCommand(x.Step),
                //        x.Status))
                //    .FirstOrDefaultAsync();

                //return virtualPalletDetails;
            }
            return null;
        }
    }
}
