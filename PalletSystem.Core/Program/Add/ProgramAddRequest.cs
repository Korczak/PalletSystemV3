using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramAddRequest
    {
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<ProgramInstruction> Instructions { get; }

        public ProgramAddRequest(string name, string description, IEnumerable<ProgramInstruction> instructions)
        {
            Name = name;
            Description = description;
            Instructions = instructions;
        }
    }
}
