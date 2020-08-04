using System.Collections;
using System.Collections.Generic;

namespace PalletSystem.Core.VirtualPallet.Details
{
    public class VirtualPalletProgram
    {
        public string ProgramName { get; }
        public int StepsDone { get; }
        public int StepsTotal { get; }
        public IEnumerable<VirtualPalletProgramStep> Steps{ get; }

        public VirtualPalletProgram(string programName, int stepsDone, int stepsTotal, IEnumerable<VirtualPalletProgramStep> steps)
        {
            ProgramName = programName;
            StepsDone = stepsDone;
            StepsTotal = stepsTotal;
            Steps = steps;
        }
    }
}