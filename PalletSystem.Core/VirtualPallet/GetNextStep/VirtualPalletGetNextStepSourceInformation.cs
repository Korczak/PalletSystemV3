using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class VirtualPalletGetNextStepSourceInformation
    {
        public string Id { get; }
        public VirtualPalletStatus Status { get; }

        public VirtualPalletGetNextStepSourceInformation(string id, VirtualPalletStatus status)
        {
            Id = id;
            Status = status;
        }
    }
}