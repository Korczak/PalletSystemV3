using Core.Pallet.Common;
using Core.Program.Command;
using System.Collections.Generic;

namespace Core.VirtualPallet.Details
{
    public class VirtualPalletDetails
    {
        public int VirtualPalletId { get; }
        public int? PalletId { get; }
        public int ProgramId {get;}
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public ProgramStepCommand NextProgramStep { get; }
        public PalletStatus PalletStatus { get; }

        public VirtualPalletDetails(
            int virtualPalletId,
            int? palletId,
            int programId,
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
