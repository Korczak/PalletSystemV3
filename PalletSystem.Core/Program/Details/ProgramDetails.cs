using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Program.Details
{
    public class ProgramDetails
    {
        public string ProgramId { get; }
        public string ProgramName { get; }
        public string ProgramDescription { get; }
        public int NumberOfProgramSteps{ get; }
        public IEnumerable<ProgramInstructionItem> Instructions { get; }

        public ProgramDetails(string programId, string programName, string programDescription, int numberOfProgramSteps, IEnumerable<ProgramInstructionItem> instructions)
        {
            ProgramId = programId;
            ProgramName = programName;
            ProgramDescription = programDescription;
            NumberOfProgramSteps = numberOfProgramSteps;
            Instructions = instructions;
        }
    }
}
