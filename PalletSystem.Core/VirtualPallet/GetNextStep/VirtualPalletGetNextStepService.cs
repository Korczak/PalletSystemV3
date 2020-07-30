using PalletSystem.Core.VirtualPallet.Constants;
using System;
using System.Threading.Tasks;

namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class VirtualPalletGetNextStepService
    {
        private readonly VirtualPalletGetNextStepAccess _access;

        public VirtualPalletGetNextStepService(VirtualPalletGetNextStepAccess access)
        {
            _access = access;
        }

        public Task<VirtualPalletGetNextStepResponse> GetNextStep(string rfid)
        {
            if (rfid == null) throw new ArgumentNullException(nameof(rfid));

            return InternalGetNextStep(rfid);
        }

        private async Task<VirtualPalletGetNextStepResponse> InternalGetNextStep(string rfid)
        {
            var palletInformation = await _access.GetPalletInformation(rfid);

            if (palletInformation == null ||
                palletInformation.Id == default || 
                palletInformation.Status == VirtualPalletStatus.Error)
                return VirtualPalletGetNextStepResponse.Failure(VirtualPalletGetNextStepResult.VirtualPalletError);

            if (palletInformation.Status == VirtualPalletStatus.Done)
                return VirtualPalletGetNextStepResponse.Failure(VirtualPalletGetNextStepResult.ProgramIsDone);

            var nextStep = await _access.GetNextStep(rfid);
            return VirtualPalletGetNextStepResponse.Success(nextStep, rfid);
        }
    }
}