using MongoDB.Driver;

namespace PalletSystem.Core.Database.Settings
{
    public class DatabaseContext
    {
        private readonly IMongoDatabase _db;
        private readonly MongoClient _client;
        public DatabaseContext(IMongoDatabase db, MongoClient client)
        {
            _db = db;
            _client = client;
        }

        public MongoClient Client { get => _client; }
        public IMongoDatabase Database { get => _db; }
        public IMongoCollection<Models.Pallet.Pallets> Pallets => _db.GetCollection<Models.Pallet.Pallets>("Pallet");
        public IMongoCollection<Models.User.Users> Users => _db.GetCollection<Models.User.Users>("User");
        public IMongoCollection<Models.ProgramScheme.ProgramSchemes> ProgramSchemes => _db.GetCollection<Models.ProgramScheme.ProgramSchemes>("ProgramScheme");
        public IMongoCollection<Models.VirtualPallet.VirtualPallets> VirtualPallets => _db.GetCollection<Models.VirtualPallet.VirtualPallets>("VirtualPallet");
        public IMongoCollection<Models.Connector.Connector> Connectors => _db.GetCollection<Models.Connector.Connector>("Connector");
        public IMongoCollection<Models.Plc.PLCs> PLCs => _db.GetCollection<Models.Plc.PLCs>("PLC");

    }
}
