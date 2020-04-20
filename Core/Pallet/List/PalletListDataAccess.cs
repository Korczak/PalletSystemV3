using Core.Database.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Pallets.List
{
    public class PalletListDataAccess
    {
        public async Task<IEnumerable<PalletInformation>> GetPalletList()
        {
            using(var handler = new DatabaseHandler())
            {
                var pallets = await handler.db.Pallets.AsQueryable()
                    .Select(x => new PalletInformation(x.Id, x.RFID, x.Status))
                    .ToListAsync();

                return pallets;
            }
        }
        
    }
}
