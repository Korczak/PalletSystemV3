using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.ProgramScheme
{
    public class ProgramStepsInstructionSchemes
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Step { get; set; }
        public string OperationMask { get; set; }
        public string Command { get; set; }
        public string Parameters { get; set; }
        public string WorkspaceSlot { get; set; }
    }
}
