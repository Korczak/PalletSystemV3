using Core.Program.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Program.Details
{
    public class ProgramDetails
    {
        public int ProgramId { get; }
        public string ProgramName { get; }
        public string ProgramDescription { get; }
        public int NumberOfSteps { get; }
        public IEnumerable<ProgramStepCommand> ProgramStepCommands { get; }

        public ProgramDetails(int programId, string programName, string programDescription, int numberOfSteps, IEnumerable<ProgramStepCommand> programStepCommands)
        {
            ProgramId = programId;
            ProgramName = programName;
            ProgramDescription = programDescription;
            NumberOfSteps = numberOfSteps;
            ProgramStepCommands = programStepCommands;
        }
    }
}
