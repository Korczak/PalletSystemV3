using System.Collections.Generic;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramInstruction
    {
        public int Step { get; }
        public string MachineMask { get; }
        public string Command { get; }
        public IEnumerable<string> Parameters { get; }
        public string WorkspaceSlot { get; }

        public ProgramInstruction(int step, string machineMask, string command, IEnumerable<string> parameters, string workspaceSlot)
        {
            Step = step;
            MachineMask = machineMask;
            Command = command;
            Parameters = parameters;
            WorkspaceSlot = workspaceSlot;
        }
    }
}