using Core.Program.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SteeringLogic.CalculateStep
{
    public class SteeringLogicRequest
    {
        public int VirtualPalletId { get; }
        public ProgramStepResult ProgramStepResult { get; }

        public SteeringLogicRequest(int virtualPalletId, ProgramStepResult programStepResult)
        {
            VirtualPalletId = virtualPalletId;
            ProgramStepResult = programStepResult;
        }
    }
}
