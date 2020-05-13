using Microsoft.Extensions.DependencyInjection;
using PalletSystem.Core.Pallet.Add;
using PalletSystem.Core.Pallet.List;
using PalletSystem.Core.Pallet.Run;
using PalletSystem.Web.Configuration;

namespace PalletSystem.Web.Pallet
{
    public class PalletsStartup : IServiceStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PalletListDataAccess>();

            services.AddSingleton<PalletAddService>();
            services.AddSingleton<PalletAddAccess>();

            services.AddSingleton<PalletRunService>();
            services.AddSingleton<PalletRunAccess>();
        }
    }
}
