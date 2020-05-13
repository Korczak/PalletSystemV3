using Microsoft.Extensions.DependencyInjection;
using PalletSystem.Core.Program.Add;
using PalletSystem.Core.Program.List;
using PalletSystem.Web.Configuration;

namespace PalletSystem.Web.Programs
{
    public class ProgramStartup : IServiceStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ProgramAddService>();
            services.AddSingleton<ProgramAddAccess>();

            services.AddSingleton<ProgramListAccess>();
        }
    }
}
