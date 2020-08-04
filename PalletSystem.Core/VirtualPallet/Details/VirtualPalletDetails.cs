using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.VirtualPallet.Constants;
using System.Collections.Generic;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletDetails
    {
        public string VirtualPalletId { get; }
        public VirtualPalletProgram VirtualPalletProgram{ get; }
        public VirtualPalletStatus PalletStatus { get; }

        public VirtualPalletDetails(string virtualPalletId, VirtualPalletProgram virtualPalletProgram, VirtualPalletStatus palletStatus)
        {
            VirtualPalletId = virtualPalletId;
            VirtualPalletProgram = virtualPalletProgram;
            PalletStatus = palletStatus;
        }
    }
}
