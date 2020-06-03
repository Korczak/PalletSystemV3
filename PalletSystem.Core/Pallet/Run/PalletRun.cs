using MongoDB.Bson;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRun
    {
        public string PalletId { get; }
        public string ProgramId { get; }

        public PalletRun(string palletId, string programId)
        {
            PalletId = palletId;
            ProgramId = programId;
        }
    }
}