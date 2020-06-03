using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using PalletSystem.Core.Program.Add;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PalletSystem.DatabaseTest.ProgramTests
{
    public class AddProgramSchemeTests : DatabaseTest
    {
        [Fact(DisplayName = "Add program with valid data")]
        public async Task AddProgramSchemeSuccess()
        {
            var programName = "new program";
            var service = new ProgramAddService(new ProgramAddAccess());
            var programInstructions = new List<ProgramInstruction>()
            {
                new ProgramInstruction(1, "1111", "Command", new List<string>{"1"}, "1"),
                new ProgramInstruction(2, "1111", "Command", new List<string>{"1"}, "2")
            };
            await service.AddProgram(new ProgramAddRequest(programName, null, programInstructions));

            using (var handler = new DatabaseHandler())
            {
                var program = await handler.db.ProgramSchemes.AsQueryable()
                    .Where(x => x.Name == programName)
                    .FirstOrDefaultAsync();
                Assert.NotNull(program);
            }
        }
    }
}
