using PalletSystem.Core.Pallet.Constant;

namespace PalletSystem.Core.VirtualPallet.List
{
    public class VirtualPalletInformation
    {
        public string VirtualPalletId { get; }
        public string RFID { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public PalletStatus PalletStatus { get; }

        public VirtualPalletInformation(string virtualPalletId, string rfid, string programName, int stepsDone, int stepsTotal, PalletStatus palletStatus)
        {
            VirtualPalletId = virtualPalletId;
            RFID = rfid;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            PalletStatus = palletStatus;
        }
    }
}
