using Core.Users.Constants;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Database.Models.Users
{
    public class User
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public bool Deleted { get; set; }
        public Role Role { get; set; }
        public bool FirstLogin { get; set; }
    }
}
