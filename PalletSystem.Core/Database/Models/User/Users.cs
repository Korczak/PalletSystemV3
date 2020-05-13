using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PalletSystem.Core.Users.Constants;

namespace PalletSystem.Core.Database.Models.User
{
    public class Users
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
