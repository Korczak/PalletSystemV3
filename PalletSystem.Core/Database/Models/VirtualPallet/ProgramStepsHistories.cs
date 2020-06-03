using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using NodaTime;
using PalletSystem.Core.Program.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class ProgramStepsHistories
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Step { get; set; }
        public LocalDateTime DateTime { get; set; }
        public string WorkspaceSlot { get; set; }
        public IEnumerable<string> Results { get; set; }
        public ProgramStatus Status { get; set; }
    }
}
