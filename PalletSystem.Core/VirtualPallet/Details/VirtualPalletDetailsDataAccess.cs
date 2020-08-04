using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletDetailsDataAccess
    {
        public async Task<VirtualPalletDetails> GetVirtualPalletDetails(string virtualPalletId)
        {
            using (var handler = new DatabaseHandler())
            {
                var programDetails = await handler.db.VirtualPallets.AsQueryable()
                    .Where(x => x.IsActive && x.Id == virtualPalletId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Program,
                        x.Status
                    })
                    //x.ProgramStepsInstructions.Select(i => new ProgramInstructionItem(i.Step, i.OperationMask, i.Command, i.Parameters)).ToList()))
                    .FirstOrDefaultAsync();

                var result = new VirtualPalletDetails(
                    programDetails.Id,
                    new VirtualPalletProgram(
                        programDetails.Program.Name,
                        programDetails.Program.ProgramStepsHistories.Count(),
                        programDetails.Program.ProgramStepsInstructions.Count(),
                        programDetails.Program.ProgramStepsHistories.Select(p => new VirtualPalletProgramStep(
                            p.Step,
                            p.Instant,
                            p.OperationMask,
                            p.WorkspaceSlot,
                            p.Results.Select(r => new VirtualPalletProgramStepResult(r.Index, r.Value, r.Status)),
                            p.Status)).ToList()),
                    programDetails.Status);
                return result;
            }
        }
    }
}
