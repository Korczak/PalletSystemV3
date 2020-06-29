using PalletSystem.Core.Pallet.Constant;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.VirtualPallet.GetNextStep
{
    public class NextStepInformation
    {
        public string OperationMask { get; }
        public VirtualPalletStatus Status { get; }
        public string Command { get; }
        public string Parameter1 { get; }
        public string Parameter2 { get; }
        public string Parameter3 { get; }
        public string Parameter4 { get; }
        public string Parameter5 { get; }

        public NextStepInformation(string operationMask, VirtualPalletStatus status, string command, string parameter1, string parameter2, string parameter3, string parameter4, string parameter5)
        {
            OperationMask = operationMask;
            Status = status;
            Command = command;
            Parameter1 = parameter1;
            Parameter2 = parameter2;
            Parameter3 = parameter3;
            Parameter4 = parameter4;
            Parameter5 = parameter5;
        }
    }
}