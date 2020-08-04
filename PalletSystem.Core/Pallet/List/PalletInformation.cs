

using PalletSystem.Core.Pallet.Constant;
using MongoDB.Bson;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.Pallet.List
{
    public class PalletInformation
    {
        public string Id { get; }
        public string VirtualPalletId { get; }
        public string RFID { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public bool IsVirtualPalletActive { get; }
        public VirtualPalletStatus VirtualPalletStatus { get; }
        public PalletStatus PalletStatus { get; }

        public PalletInformation(string id, string rFID, PalletStatus palletStatus)
        {
            Id = id;
            RFID = rFID;
            PalletStatus = palletStatus;
            IsVirtualPalletActive = false;
        }

        public PalletInformation(string id, string virtualPalletId, string rFID, string programName, int stepsDone, int stepsTotal, VirtualPalletStatus virtualPalletStatus, PalletStatus palletStatus)
        {
            Id = id;
            VirtualPalletId = virtualPalletId;
            RFID = rFID;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            VirtualPalletStatus = virtualPalletStatus;
            PalletStatus = palletStatus;
            IsVirtualPalletActive = true;
        }
    }
}
