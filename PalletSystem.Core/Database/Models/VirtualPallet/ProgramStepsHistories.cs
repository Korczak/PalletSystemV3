using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NodaTime;
using PalletSystem.Core.Program.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class ProgramStepsHistories
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public int Step { get; set; }
        public LocalDateTime DateTime { get; set; }
        public string WorkspaceSlot { get; set; }
        public IEnumerable<string> Results { get; set; }
        public ProgramStatus Status { get; set; }
    }
}
