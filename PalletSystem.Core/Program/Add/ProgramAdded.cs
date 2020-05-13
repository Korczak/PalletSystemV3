using System.Collections.Generic;

namespace PalletSystem.Core.Program.Add
{
    public class ProgramAdded
    {
        public string Name { get; }
        public string Description { get; }
        public IEnumerable<ProgramInstruction> Instructions { get; }

        public ProgramAdded(string name, string description, IEnumerable<ProgramInstruction> instructions)
        {
            Name = name;
            Description = description;
            Instructions = instructions;
        }
    }
}