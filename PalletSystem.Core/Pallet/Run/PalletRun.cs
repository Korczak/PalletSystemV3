using MongoDB.Bson;

namespace PalletSystem.Core.Pallet.Run
{
    public class PalletRun
    {
        public ObjectId PalletId { get; }
        public ObjectId ProgramId { get; }

        public PalletRun(ObjectId palletId, ObjectId programId)
        {
            PalletId = palletId;
            ProgramId = programId;
        }
    }
}