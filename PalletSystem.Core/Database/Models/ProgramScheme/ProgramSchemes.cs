using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Database.Models.VirtualPallet;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.ProgramScheme
{
    public class ProgramSchemes
    {

        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public IEnumerable<ProgramStepsInstructions> ProgramStepsInstructions { get; set; } = new List<ProgramStepsInstructions>();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
    }
}
