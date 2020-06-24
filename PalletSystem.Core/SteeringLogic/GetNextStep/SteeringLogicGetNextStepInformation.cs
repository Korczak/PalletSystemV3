using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.SteeringLogic.GetNextStep
{
    public class SteeringLogicGetNextStepInformation
    {
        public string OperationMask { get; }
        public PalletStatus Status { get; }
        public string Command { get; }
        public IEnumerable<string> Parameters { get; }

        public SteeringLogicGetNextStepInformation(string operationMask, PalletStatus status, string command, IEnumerable<string> parameters)
        {
            OperationMask = operationMask;
            Status = status;
            Command = command;
            Parameters = parameters;
        }
    }
}
