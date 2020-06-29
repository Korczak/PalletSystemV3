namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class VirtualPalletGetNextStepResponse
    {
        public VirtualPalletGetNextStepResult Result { get; }
        public NextStepInformation NextStep { get; }

        private VirtualPalletGetNextStepResponse(VirtualPalletGetNextStepResult result, NextStepInformation nextStep)
        {
            Result = result;
            NextStep = nextStep;
        }

        public static VirtualPalletGetNextStepResponse Success(NextStepInformation nextStep) => new VirtualPalletGetNextStepResponse(VirtualPalletGetNextStepResult.NextStepAvailable, nextStep);

        public static VirtualPalletGetNextStepResponse Failure(VirtualPalletGetNextStepResult result) => new VirtualPalletGetNextStepResponse(result, null);
    }
}