using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.Program.List
{
    public class ProgramListAccess
    {
        public async Task<IEnumerable<ProgramInformation>> GetProgramList() 
        {
            using(var handler = new DatabaseHandler())
            {
                return await handler.db.ProgramSchemes.AsQueryable()
                    .Where(x => !x.IsDelete)
                    .Select(x => new ProgramInformation(x.Id.ToString(), x.Name, x.Description, x.ProgramStepsInstructions.Count()))
                    .ToListAsync();
            }
        }
    }
}
