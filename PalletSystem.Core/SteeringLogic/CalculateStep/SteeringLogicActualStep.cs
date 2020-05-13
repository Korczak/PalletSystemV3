namespace PalletSystem.Core.SteeringLogic.CalculateStep
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
