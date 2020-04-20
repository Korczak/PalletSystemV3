using Core.Pallet.Common;
using Core.Program.Command;

namespace Core.VirtualPallet.List
{
    public class VirtualPalletInformation
    {
        public int VirtualPalletId { get; }
        public int? PalletId { get; }
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public PalletStatus PalletStatus { get; }

        public VirtualPalletInformation(int virtualPalletId, int? palletId, string programName, int stepsDone, int stepsTotal, PalletStatus palletStatus)
        {
            VirtualPalletId = virtualPalletId;
            PalletId = palletId;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            PalletStatus = palletStatus;
        }
    }
}
