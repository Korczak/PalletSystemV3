
namespace PalletSystem.Core.SteeringLogic.CalculateStep
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
