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
                            Parameter1 = instruction.Parameter1,
                            Parameter2 = instruction.Parameter2,
                            Parameter3 = instruction.Parameter3,
                            Parameter4 = instruction.Parameter4,
                            Parameter5 = instruction.Parameter5,
                            Step = instruction.Step
                        });
                    }

                    programInstruction.Add(new ProgramStepsInstructions()
                    {
                        Command = "",
                        OperationMask = 5,
                        Step = programInstruction.Count + 1
                    });


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
