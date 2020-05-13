using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program.Details
{
    public class ProgramDetailsDataAccess
    {
        public async Task<ProgramDetails> GetProgramDetails(int id)
        {
            //using (var db = new PalletDB())
            //{
            //    var programInstructions = await db.ProgramStepsInstructions
            //        .Where(x => x.ProgramId == id)
            //        .Select(x => new ProgramStepCommand(
            //            x.Step,
            //            x.MachineMask,
            //            x.Command,
            //            x.Parameter1,
            //            x.Parameter2,
            //            x.Parameter3,
            //            x.Parameter4,
            //            x.Parameter5,
            //            x.WorkspaceSlot))
            //        .ToListAsync();

            //    var programDetails = await db.Programs
            //        .LoadWith(x => x.Instructions)
            //        .Where(x => x.Id == id)
            //        .Select(x => new ProgramDetails(x.Id, x.Name, x.Description, x.NumberOfSteps, programInstructions))
            //        .FirstOrDefaultAsync();

            //    return programDetails;
            //}
            return null;
        }
    }
}
