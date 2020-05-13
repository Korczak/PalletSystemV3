using PalletSystem.Core.Pallet.Constant;
using System.Collections.Generic;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletDetails
    {
        public string VirtualPalletId { get; }
        public string PalletId { get; }
        public string ProgramId {get;}
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public ProgramStepCommand NextProgramStep { get; }
        public PalletStatus PalletStatus { get; }

        public VirtualPalletDetails(
            string virtualPalletId,
            string palletId,
            string programId,
            string programName,
            int stepsDone,
            int stepsTotal,
            ProgramStepCommand nextProgramStep,
            PalletStatus palletStatus)
        {
            VirtualPalletId = virtualPalletId;
            PalletId = palletId;
            ProgramId = programId;
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            NextProgramStep = nextProgramStep;
            PalletStatus = palletStatus;
        }
    }
}
