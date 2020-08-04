using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Program.Details
{
    public class ProgramInstructionItem
    {
        public int NumberOfStep { get; }
        public int OperationMask { get; }
        public string Command { get; }
        public string Parameters { get; }

        public ProgramInstructionItem(int numberOfStep, int operationMask, string command, string parameters)
        {
            NumberOfStep = numberOfStep;
            OperationMask = operationMask;
            Command = command;
            Parameters = parameters;
        }
    }
}
