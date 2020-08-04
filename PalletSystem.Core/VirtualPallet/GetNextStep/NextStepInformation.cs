using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class NextStepInformation
    {
        public int OperationMask { get; }
        public VirtualPalletStatus Status { get; }
        public string Command { get; }
        public string Parameters { get; }

        public NextStepInformation(int operationMask, VirtualPalletStatus status, string command, string parameters)
        {
            OperationMask = operationMask;
            Status = status;
            Command = command;
            Parameters = parameters;
        }
    }
}