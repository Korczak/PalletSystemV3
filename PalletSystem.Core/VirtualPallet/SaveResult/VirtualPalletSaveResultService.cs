using NodaTime;
using PalletSystem.Core.Pallet.StatusHub;
using PalletSystem.Core.VirtualPallet.StatusHub;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.SaveResult
{
    public class VirtualPalletSaveResultService
    {
        private readonly VirtualPalletSaveResultAccess _access;
        private readonly VirtualPalletStatusHub _statusHub;
        private readonly IClock _clock;

        public VirtualPalletSaveResultService(VirtualPalletSaveResultAccess access, VirtualPalletStatusHub statusHub, IClock clock)
        {
            _access = access;
            _statusHub = statusHub;
            _clock = clock;
        }

        public Task SaveResult(VirtualPalletSaveResultRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            return InternalSaveResult(request);
        }

        private async Task InternalSaveResult(VirtualPalletSaveResultRequest request)
        {
            var virtualPalletSource = await _access.GetVirtualPalletSource(request.RFID);

            if (virtualPalletSource == null || virtualPalletSource.Id == default)
            {
                return;
            }

            var processing = new VirtualPalletSaveResultProcessing(virtualPalletSource, request, _clock);
            await _statusHub.ActualVirtualStatusUpdate(processing.Saved.VirtualPalletStatus);
            await _access.SaveResults(processing.Saved);
        }
    }
}