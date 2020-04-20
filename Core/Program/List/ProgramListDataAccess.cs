using Core.Database.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Program.List
{
    public class ProgramListDataAccess
    {
        public async Task<IEnumerable<ProgramInformation>> GetProgramList() 
        {
            using(var handler = new DatabaseHandler())
            {
                //var programList = await handler.db.Pallets
                //    .Select(x => new ProgramInformation(x.Id, x.Name, x.Description, x.NumberOfSteps))
                //    .ToListAsync();

                return null;
            }
        }
    }
}
