using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class Programs
    {
        public ObjectId ProgramId { get; set; }
        public IEnumerable<ProgramStepsHistories> ProgramStepsHistories { get; set; } = new List<ProgramStepsHistories>();
    }
}
