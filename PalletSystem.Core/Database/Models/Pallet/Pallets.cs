using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PalletSystem.Core.Pallet.Constant;

namespace PalletSystem.Core.Database.Models.Pallet
{
    public class Pallets
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string RFID { get; set; }
        public PalletStatus Status { get; set; }
        public bool IsDelete { get; set; }
    }
}
