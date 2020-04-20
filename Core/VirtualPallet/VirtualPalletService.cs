using Core.VirtualPallet.Details;
using Core.VirtualPallet.List;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.VirtualPallet
{
    public class VirtualPalletService
    {
        private readonly VirtualPalletListDataAccess _virtualPalletListDataAccess;
        private readonly VirtualPalletDetailsDataAccess _virtualPalletDetailsDataAccess;

        public VirtualPalletService(
            VirtualPalletListDataAccess virtualPalletListDataAccess,
            VirtualPalletDetailsDataAccess virtualPalletDetailsDataAccess)
        {
            _virtualPalletListDataAccess = virtualPalletListDataAccess;
            _virtualPalletDetailsDataAccess = virtualPalletDetailsDataAccess;
        }

        public async Task<IEnumerable<VirtualPalletInformation>> GetVirtualPalletList()
        {
            var virtualPallets = await _virtualPalletListDataAccess.GetVirtualPalletList();
            Log.Information("HALO");
            return virtualPallets;
        }

        public async Task<VirtualPalletDetails> GetVirtualPalletDetails(int id)
        {
            var virtualPalletsDetails = await _virtualPalletDetailsDataAccess.GetVirtualPalletDetails(id);
            return virtualPalletsDetails;
        }
    }
}
