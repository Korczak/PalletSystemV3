using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Collections.Generic;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class ProgramStepsInstructions
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public int Step { get; set; }
        public string OperationMask { get; set; }
        public string Command { get; set; }
        public IEnumerable<string> Parameters { get; set; } = new List<string>();
    }
}