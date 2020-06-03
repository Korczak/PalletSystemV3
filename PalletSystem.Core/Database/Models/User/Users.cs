using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using PalletSystem.Core.Users.Constants;

namespace PalletSystem.Core.Database.Models.User
{
    public class Users
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
