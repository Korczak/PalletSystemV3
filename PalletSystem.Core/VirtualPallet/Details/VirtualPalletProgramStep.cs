using NodaTime;
using PalletSystem.Core.Program.Constant;
using System.Collections.Generic;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletProgramStep
    {

        public int Step { get; set; }
        public Instant Instant { get; set; }
        public string OperationMask { get; set; }
        public int WorkspaceSlot { get; set; }
        public IEnumerable<VirtualPalletProgramStepResult> Results { get; set; }
        public ProgramStatus Status { get; set; }

        public VirtualPalletProgramStep(
            int step,
            Instant instant,
            string operationMask,
            int workspaceSlot,
            IEnumerable<VirtualPalletProgramStepResult> results,
            ProgramStatus status)
        {
            Step = step;
            Instant = instant;
            OperationMask = operationMask;
            WorkspaceSlot = workspaceSlot;
            Results = results;
            Status = status;
        }
    }
}