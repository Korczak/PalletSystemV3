using Microsoft.Extensions.DependencyInjection;

namespace PalletSystem.Web.Configuration
{
    public interface IServiceStartup
    {
        void ConfigureServices(IServiceCollection services);
    }
}
