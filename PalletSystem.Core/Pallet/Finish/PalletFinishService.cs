using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PalletSystem.Core.Pallet.Finish
{
    public class PalletFinishService
    {
        private readonly PalletFinishAccess _access;

        public PalletFinishService(PalletFinishAccess access)
        {
            _access = access;
        }

        public Task FinishPallet(PalletFinishRequest request)
        {
            if (request == null || request.PalletId == null || request.RFID == null) throw new ArgumentNullException(nameof(request));

            return InternallFinishPallet(request);
        }

        private async Task InternallFinishPallet(PalletFinishRequest request)
        {
            var palletSource = await _access.GetPalletStatus(request.PalletId);

            if (palletSource == default)
                return;
            if (palletSource.Status == Constant.PalletStatus.Running)
                return;

            await _access.FinishPallet(new PalletFinished(request.PalletId, request.RFID));
        }
    }
}
