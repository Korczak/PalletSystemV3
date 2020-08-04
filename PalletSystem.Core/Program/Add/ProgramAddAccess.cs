using PalletSystem.Core.Database.Models.ProgramScheme;
using PalletSystem.Core.Database.Models.VirtualPallet;
using PalletSystem.Core.Database.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramAddAccess
    {
        public async Task AddProgram(ProgramAdded added)
        {
            using (var handler = new DatabaseHandler())
            {
                await handler.StartTransaction();
                try
                {
                    var programInstruction = new List<ProgramStepsInstructions>();

                    foreach(var instruction in added.Instructions)
                    {
                        programInstruction.Add(new ProgramStepsInstructions()
                        {
                            Command = instruction.Command,
                            OperationMask = instruction.MachineMask,
                            Parameters = instruction.Parameters,
                            Step = instruction.Step
                        });
                    }

                    var programToInsert = new ProgramSchemes()
                    {
                        Description = added.Description,
                        Name = added.Name,
                        ProgramStepsInstructions = programInstruction
                    };

                    await handler.db.ProgramSchemes.InsertOneAsync(programToInsert);
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
