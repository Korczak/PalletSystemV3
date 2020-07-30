namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class VirtualPalletGetNextStepResponse
    {
        public VirtualPalletGetNextStepResult Result { get; }
        public NextStepInformation NextStep { get; }
        public string Rfid { get; }

        private VirtualPalletGetNextStepResponse(VirtualPalletGetNextStepResult result, NextStepInformation nextStep, string rfid)
        {
            Result = result;
            NextStep = nextStep;
            Rfid = rfid;
        }

        public static VirtualPalletGetNextStepResponse Success(NextStepInformation nextStep, string rfid) => new VirtualPalletGetNextStepResponse(VirtualPalletGetNextStepResult.NextStepAvailable, nextStep, rfid);

        public static VirtualPalletGetNextStepResponse Failure(VirtualPalletGetNextStepResult result) => new VirtualPalletGetNextStepResponse(result, null, null);
    }
}