using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database.Models.VirtualPallets
{
    public class VirtualPalletModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<ProgramStepsHistoryModel> ProgramStepsHistories {get;set;}
    }
}
