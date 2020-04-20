using Core.Database.Models.Pallets;
using Core.Database.Models.Users;
using Core.Database.Models.VirtualPallets;
using MongoDB.Driver;

namespace Core.Database.Settings
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _db;
        public readonly MongoClient _client;
        public DatabaseContext(IMongoDatabase db, MongoClient client)
        {
            _db = db;
            _client = client;
        }

        public IMongoCollection<PalletModel> Pallets => _db.GetCollection<PalletModel>("Pallet");
        public IMongoCollection<VirtualPalletModel> VirtualPallets => _db.GetCollection<VirtualPalletModel>("VirtualPallet");
        public IMongoCollection<User> Users => _db.GetCollection<User>("User");

    }
}
