using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using NodaTime;
using PalletSystem.Core.Program.Constant;
using System.Collections.Generic;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class ProgramStepsHistories
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Step { get; set; }
        public Instant Instant { get; set; }
        public int OperationMask { get; set; }
        public int WorkspaceSlot { get; set; }
        public IEnumerable<ProgramStepResultItem> Results { get; set; }
        public ProgramStatus Status { get; set; }
    }
}