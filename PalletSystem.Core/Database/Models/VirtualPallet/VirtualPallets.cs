using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.VirtualPallet.Constants;

namespace PalletSystem.Core.Database.Models.VirtualPallet
{
    public class VirtualPallets
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string PalletId { get; set; }

        public Programs Program { get; set; }
        public VirtualPalletStatus Status { get; set; }
        public bool IsActive { get; set; }
    }
}