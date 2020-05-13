using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PalletSystem.Core.Pallet.Constant;
using System;
using System.Collections.Generic;
using System.Text;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class VirtualPallets
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId PalletId { get; set; }
        public Programs Program { get; set; }
        public PalletStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}
