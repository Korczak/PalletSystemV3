using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Add
{
    public class PalletAddService
    {
        private readonly PalletAddAccess _access;

        public PalletAddService(PalletAddAccess access)
        {
            _access = access;
        }

        public async Task<PalletAddResult> AddPallet(PalletAddRequest request)
        {
            if (request == null || request.RFID == null) throw new ArgumentNullException(nameof(request));

            var existingPallet = await _access.GetExistingPallet(request.RFID);
            if (existingPallet != default)
                return PalletAddResult.PalletAlreadyExists;

            await _access.AddPallet(new PalletAdded(request.RFID));
            return PalletAddResult.PalletAdded;
        }
    }
}
