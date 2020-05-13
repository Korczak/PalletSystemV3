namespace PalletSystem.Core.Program.Details
{
    public class ProgramStepCommand
    {
        public int ProgramStepId { get; }
        public string MachineMask { get; }
        public string Command { get; }
        public string Parameter1 { get; }
        public string Parameter2 { get; }
        public string Parameter3 { get; }
        public string Parameter4 { get; }
        public string Parameter5 { get; }
        public string WorkspaceSlot { get; }

        public ProgramStepCommand(
            int programStepId,
            string machineMask,
            string command,
            string parameter1,
            string parameter2,
            string parameter3,
            string parameter4,
            string parameter5,
            string workspaceSlot)
        {
            ProgramStepId = programStepId;
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