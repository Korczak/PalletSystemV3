using System.Collections.Generic;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramInstruction
    {
        public int Step { get; }
        public int MachineMask { get; }
        public string Command { get; }
        public string Parameters { get; }

        public ProgramInstruction(int step, int machineMask, string command, string parameters)
        {
            Step = step;
            MachineMask = machineMask;
            Command = command;
            Parameters = parameters;
        }
    }
}