using Microsoft.AspNetCore.Builder;

namespace PalletSystem.Web.Configuration
{
    public interface IEndpointsSetup
    {
        void ConfigureEndpoints(IApplicationBuilder appBuilder);
    }
}