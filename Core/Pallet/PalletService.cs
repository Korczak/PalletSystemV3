using Core.Pallet.ProgramPallet;
using Core.Pallets.List;
using Core.Pallets.PalletData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Pallets
{
    public class PalletService
    {
        private readonly PalletDataAccess _palletDataAccess;
        private readonly PalletListDataAccess _palletListDataAccess;
        private readonly PalletToProgramDataAccess _palletToProgramDataAccess;

        public PalletService(PalletDataAccess palletDataAccess, PalletListDataAccess palletListDataAccess, PalletToProgramDataAccess palletToProgramDataAccess)
        {
            _palletDataAccess = palletDataAccess;
            _palletListDataAccess = palletListDataAccess;
            _palletToProgramDataAccess = palletToProgramDataAccess;
        }

        public async Task<IEnumerable<PalletInformation>> GetPalletList()
        {
            var pallets = await _palletListDataAccess.GetPalletList();
            return pallets;
        }

        public async Task<PalletToInsertResponse> InsertPallet(PalletToInsertRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var response = await _palletDataAccess.InsertPallet(request);
            return response;
        }

        public async Task<PalletToProgramInformation> GetPalletToProgramInformation(int id)
        {
            var palletInformation = await _palletToProgramDataAccess.GetPalletToProgramInformation(id);

            return palletInformation;
        }

        public async Task<PalletToProgramResponse> ProgramPallet(PalletToProgramRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var response = await _palletToProgramDataAccess.ProgramPallet(request);
            return response;
        }
    }
}
