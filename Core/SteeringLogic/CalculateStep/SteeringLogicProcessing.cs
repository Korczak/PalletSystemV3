using Core.SteeringLogic.Information;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.SteeringLogic.CalculateStep
{
    public class SteeringLogicProcessing
    {
        public SteeringLogicState State { get; }
        public int VirtualPalletId { get; }


        public SteeringLogicProcessing(SteeringLogicRequest request, SteeringLogicStepInformation stepInformation)
        {
            if (IsNextStepAvailable(stepInformation))
            {
                State = SteeringLogicState.NextStep;
                VirtualPalletId = request.VirtualPalletId;
            }
            else
            {
                State = SteeringLogicState.Done;
                VirtualPalletId = request.VirtualPalletId;
            }
        }

        private bool IsNextStepAvailable(SteeringLogicStepInformation stepInformation)
        {
            if (stepInformation.StepId < stepInformation.TotalSteps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
