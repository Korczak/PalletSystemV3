using Core.Database.Models.Pallets;
using Core.Database.Models.VirtualPallets;
using MongoDB.Driver.Linq;

namespace Core.Database.Settings
{
    public interface IDatabaseContext
    {
        IMongoQueryable<PalletModel> Pallets { get; }
        IMongoQueryable<VirtualPalletModel> VirtualPallets { get; }

    }
}
