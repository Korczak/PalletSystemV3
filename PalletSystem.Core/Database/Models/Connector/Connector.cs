using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using NodaTime;

namespace PalletSystem.Core.Database.Models.Connector
{
    public class Connector
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public bool Connected { get; set; }
        public LocalDateTime LastConnected { get; set; }
    }
}