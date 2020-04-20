using Core.Program.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SteeringLogic.CalculateStep
{
    public class SteeringLogicActualStep
    {
        public int VirtualPalletId { get; }
        public ProgramStepCommand NextProgramStepCommand { get; }

        public SteeringLogicActualStep(int virtualPalletId, ProgramStepCommand nextProgramStepCommand)
        {
            VirtualPalletId = virtualPalletId;
            NextProgramStepCommand = nextProgramStepCommand;
        }
    }
}
