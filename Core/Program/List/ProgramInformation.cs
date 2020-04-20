using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Program.List
{
    public class ProgramInformation
    {
        public int ProgramId { get; }
        public string ProgramName { get; }
        public string ProgramDescription { get; }
        public int NumberOfProgramSteps{ get; }

        public ProgramInformation(int programId, string programName, string programDescription, int numberOfProgramSteps)
        {
            ProgramId = programId;
            ProgramName = programName;
            ProgramDescription = programDescription;
            NumberOfProgramSteps = numberOfProgramSteps;
        }
    }
}
