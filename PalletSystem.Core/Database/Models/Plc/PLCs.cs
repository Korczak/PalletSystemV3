using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.Plc
{
    public class PLCs
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string ConnectorId { get; set; }
        public string Name { get; set; }
        public ConnectionStatus ConnectionStatus { get; set; }

    }
}
