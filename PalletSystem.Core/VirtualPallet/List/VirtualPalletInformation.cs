using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.VirtualPallet.List
{
    public class VirtualPalletInformation
    {
        public string VirtualPalletId { get; }
        public string RFID { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public VirtualPalletStatus VirtualPalletStatus { get; }

        public VirtualPalletInformation(string virtualPalletId, string rfid, string programName, int stepsDone, int stepsTotal, VirtualPalletStatus virtualPalletStatus)
        {
            VirtualPalletId = virtualPalletId;
            RFID = rfid;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            VirtualPalletStatus = virtualPalletStatus;
        }
    }
}
