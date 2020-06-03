using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class VirtualPallets
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PalletId { get; set; }
        public Programs Program { get; set; }
        public PalletStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
