using Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.VirtualPallet.List
{
    public class VirtualPalletListDataAccess
    {
        public async Task<IEnumerable<VirtualPalletInformation>> GetVirtualPalletList()
        {
            //using(var db = new PalletDB())
            //{
            //    var virtualPallets = await db.VirtualPallets
            //        .Select(x => new VirtualPalletInformation(x.Id, x.PalletId, x.Program.Name, x.StepId, x.Program.NumberOfSteps, x.Status))
            //        .ToListAsync();

            //    return virtualPallets;
            //}
            return null;
        }
    }
}
