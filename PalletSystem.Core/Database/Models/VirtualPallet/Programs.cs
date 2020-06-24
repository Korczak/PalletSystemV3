using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class Programs
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int ActiveStep { get; set; }
        public IEnumerable<ProgramStepsHistories> ProgramStepsHistories { get; set; } = new List<ProgramStepsHistories>();
        public IEnumerable<ProgramStepsInstructions> ProgramStepsInstructions { get; set; } = new List<ProgramStepsInstructions>();
    }
}
