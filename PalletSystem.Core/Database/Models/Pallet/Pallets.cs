using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Pallet.Constant;

namespace PalletSystem.Core.Database.Models.Pallet
{
    public class Pallets
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string RFID { get; set; }
        public PalletStatus Status { get; set; }
        public bool IsDelete { get; set; }
    }
}