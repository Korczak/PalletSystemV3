using PalletSystem.Core.Database.Settings;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Serilog;

namespace PalletSystem.Core.Pallet.List
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

                var palletInfo = from virtualPallet in handler.db.VirtualPallets.AsQueryable()
                                 where virtualPallet.IsActive
                                 join pallet in handler.db.Pallets.AsQueryable() on virtualPallet.PalletId equals pallet.Id
                                 join program in handler.db.ProgramSchemes.AsQueryable() on virtualPallet.Program.Id equals program.Id
                                 select new PalletInformation(
                                     pallet.Id,
                                     virtualPallet.Id,
                                     pallet.RFID,
                                     program.Name,
                                     virtualPallet.Program.ProgramStepsHistories.Count(),
                                     program.ProgramStepsInstructions.Count(),
                                     virtualPallet.Status,
                                     pallet.Status);
                var virtualPallets = await palletInfo.ToListAsync();

                pallets = pallets.Where(x => !virtualPallets.Any(v => v.RFID == x.RFID)).ToList();

                return pallets.Concat(virtualPallets);
            }
        }
        
    }
}
