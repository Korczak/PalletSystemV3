using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using PalletSystem.Core.Database.Settings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.List
{
    public class VirtualPalletListDataAccess
    {
        public async Task<IEnumerable<VirtualPalletInformation>> GetVirtualPalletList()
        {
            using (var handler = new DatabaseHandler())
            {
                var palletInfo = from virtualPallets in handler.db.VirtualPallets.AsQueryable()
                                   where virtualPallets.IsActive
                                   join program in handler.db.ProgramSchemes.AsQueryable() on virtualPallets.Program.Id equals program.Id
                                   join pallet in handler.db.Pallets.AsQueryable() on virtualPallets.PalletId equals pallet.Id
                                   select new VirtualPalletInformation(
                                       virtualPallets.Id,
                                       pallet.RFID, 
                                       program.Name, 
                                       virtualPallets.Program.ProgramStepsHistories.Count(), 
                                       program.ProgramStepsInstructionSchemes.Count(),
                                       virtualPallets.Status);

                return await palletInfo.ToListAsync();
            }
        }
    }
}
