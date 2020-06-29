using MongoDB.Bson;
using PalletSystem.Core.Database.Models.VirtualPallet;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRun
    {
        public string PalletId { get; }
        public string ProgramId { get; }
        public ImmutableList<ProgramStepsInstructions> Instructions { get; }

        public PalletRun(string palletId, string programId, IEnumerable<ProgramStepsInstructions> instructions)
        {
            PalletId = palletId;
            ProgramId = programId;
            Instructions = instructions.ToImmutableList();
        }
    }
}