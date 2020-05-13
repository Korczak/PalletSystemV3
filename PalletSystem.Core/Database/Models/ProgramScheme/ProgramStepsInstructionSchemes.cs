using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.ProgramScheme
{
    public class ProgramStepsInstructionSchemes
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Step { get; set; }
        public string MachineMask { get; set; }
        public string Command { get; set; }
        public IEnumerable<string> Parameters { get; set; } = new List<string>();
        public string WorkspaceSlot { get; set; }
    }
}
