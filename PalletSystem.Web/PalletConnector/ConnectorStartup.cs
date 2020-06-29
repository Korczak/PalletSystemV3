using Microsoft.Extensions.DependencyInjection;
using PalletSystem.Core.Devices.ConnectConnector;
using PalletSystem.Core.Devices.SyncConnector;
using PalletSystem.Core.Devices.UpdateConnections;
using PalletSystem.Core.Pallet.Run;
using PalletSystem.Core.VirtualPallet.GetNextStep;
using PalletSystem.Core.VirtualPallet.SaveResult;
using PalletSystem.Web.Configuration;

namespace PalletSystem.Web.PalletConnector
{
    public class ConnectorStartup : IServiceStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ConnectConnectorAccess>();
            services.AddSingleton<ConnectConnectorService>();

            services.AddSingleton<UpdateConnectionsAccess>();
            services.AddSingleton<UpdateConnectionsHub>();
            services.AddSingleton<UpdateConnectionsService>();

            services.AddSingleton<SyncConnectorAccess>();
            services.AddSingleton<SyncConnectorService>();

            services.AddSingleton<PalletRunAccess>();
            services.AddSingleton<PalletRunService>();

            services.AddSingleton<VirtualPalletSaveResultAccess>();
            services.AddSingleton<VirtualPalletSaveResultService>();

            services.AddSingleton<VirtualPalletGetNextStepAccess>();
            services.AddSingleton<VirtualPalletGetNextStepService>();
        }
    }
}