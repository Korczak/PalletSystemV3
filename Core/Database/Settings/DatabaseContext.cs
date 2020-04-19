using Core.Database.Models.Pallets;
using Core.Database.Models.VirtualPallets;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Core.Database.Settings
{
    public class DatabaseContext : IDatabaseContext
    {
        private readonly IMongoDatabase _db;
        public readonly MongoClient _client;
        public DatabaseContext(IMongoDatabase db, MongoClient client)
        {
            _db = db;
            _client = client;
        }

        public IMongoCollection<PalletModel> PalletsCollection => _db.GetCollection<PalletModel>("Pallet");
        public IMongoQueryable<PalletModel> Pallets => _db.GetCollection<PalletModel>("Pallet").AsQueryable();
        public IMongoQueryable<VirtualPalletModel> VirtualPallets => _db.GetCollection<VirtualPalletModel>("VirtualPallet").AsQueryable();

    }
}
