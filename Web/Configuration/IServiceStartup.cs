using Microsoft.Extensions.DependencyInjection;

namespace Web.Configuration
{
    public interface IServiceStartup
    {
        void ConfigureServices(IServiceCollection services);
    }
}
