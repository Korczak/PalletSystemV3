using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.SteeringLogic.Information
{
    public class SteeringLogicStepInformation
    {
        public int StepId { get; }
        public int TotalSteps { get; }

        public SteeringLogicStepInformation(int stepId, int totalSteps)
        {
            StepId = stepId;
            TotalSteps = totalSteps;
        }
    }
}
