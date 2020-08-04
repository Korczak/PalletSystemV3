using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program.Details
{
    public class ProgramDetailsDataAccess
    {
        public async Task<ProgramDetails> GetProgram(string programId)
        {
            using (var handler = new DatabaseHandler())
            {
                var programDetails = await handler.db.ProgramSchemes.AsQueryable()
                    .Where(x => !x.IsDelete && x.Id == programId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Name,
                        x.Description,
                        x.ProgramStepsInstructions
                    })
                        //x.ProgramStepsInstructions.Select(i => new ProgramInstructionItem(i.Step, i.OperationMask, i.Command, i.Parameters)).ToList()))
                    .FirstOrDefaultAsync();

                var result = new ProgramDetails(
                    programDetails.Id,
                    programDetails.Name,
                    programDetails.Description,
                    programDetails.ProgramStepsInstructions.Count(),
                    programDetails.ProgramStepsInstructions.Select(i => new ProgramInstructionItem(i.Step, i.OperationMask, i.Command, i.Parameters)));

                return result;
            }
        }
    }
}