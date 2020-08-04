using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PalletSystem.Core.Pallet.Add;
using PalletSystem.Core.Pallet.Finish;
using PalletSystem.Core.Pallet.List;
using PalletSystem.Core.Pallet.Run;
using PalletSystem.Core.Pallet.StatusHub;
using PalletSystem.Core.VirtualPallet.Details;
using PalletSystem.Core.VirtualPallet.StatusHub;
using PalletSystem.Web.Configuration;

namespace PalletSystem.Web.Pallet
{
    public class PalletsStartup : IServiceStartup, IEndpointsSetup
    {
        public void ConfigureEndpoints(IApplicationBuilder appBuilder)
        {
            appBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<PalletStatusHub>("/palletStatusUpdateHub");
                endpoints.MapHub<VirtualPalletStatusHub>("/virtualPalletStatusUpdateHub");
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PalletStatusHub>();
            services.AddSingleton<VirtualPalletStatusHub>();

            services.AddSingleton<PalletListDataAccess>();

            services.AddSingleton<VirtualPalletDetailsDataAccess>();

            services.AddSingleton<PalletAddService>();
            services.AddSingleton<PalletAddAccess>();

            services.AddSingleton<PalletRunService>();
            services.AddSingleton<PalletRunAccess>();

            services.AddSingleton<PalletFinishService>();
            services.AddSingleton<PalletFinishAccess>();
        }
    }
}
