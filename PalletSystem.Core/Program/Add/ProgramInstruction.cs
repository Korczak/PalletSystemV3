using System.Collections.Generic;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramInstruction
    {
        public int Step { get; }
        public int MachineMask { get; }
        public string Command { get; }
        public string Parameter1 { get; }
        public string Parameter2 { get; }
        public string Parameter3 { get; }
        public string Parameter4 { get; }
        public string Parameter5 { get; }
        public int WorkspaceSlot { get; }

        public ProgramInstruction(int step, int machineMask, string command, string parameter1, string parameter2, string parameter3, string parameter4, string parameter5, int workspaceSlot)
        {
            Step = step;
            MachineMask = machineMask;
            Command = command;
            Parameter1 = parameter1;
            Parameter2 = parameter2;
            Parameter3 = parameter3;
            Parameter4 = parameter4;
            Parameter5 = parameter5;
            WorkspaceSlot = workspaceSlot;
        }
    }
}