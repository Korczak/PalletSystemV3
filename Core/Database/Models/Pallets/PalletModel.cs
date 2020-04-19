using Core.Pallet.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Database.Models.Pallets
{
    public class PalletModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string RFID { get; set; }
        public PalletStatus Status { get; set; }
    }
}
