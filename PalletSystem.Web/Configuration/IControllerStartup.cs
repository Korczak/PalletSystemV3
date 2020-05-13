using Microsoft.AspNetCore.Builder;

namespace PalletSystem.Web.Configuration
{
    public interface IControllerStartup
    {
        void ConfigureController(IApplicationBuilder app);
    }
}
