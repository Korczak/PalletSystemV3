using Core.Configuration;
using Core.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Serilog;
using System.Linq;

namespace Web.Configuration
{
    public class WebStartup : IStartupStep
    {
        const string DEVELOPMENT_CLIENT_URL = "http://localhost:8080";
        private readonly IApplicationBuilder _app;
        private readonly IWebHostEnvironment _env;
        private readonly Config _config;

        public WebStartup(IApplicationBuilder app, IWebHostEnvironment env, Config config)
        {
            _app = app;
            _env = env;
            _config = config;
        }

        public IStartupValidation Configure()
        {
            if (_env.IsDevelopment())
            {
                _app.UseDeveloperExceptionPage();
            }

            if (_config.ServeSwaggerUI)
            {
                _app.UseOpenApi();
                _app.UseSwaggerUi3();
            }

            _app.UseMiddleware<ErrorLoggingMiddleware>();
            _app.UseRouting();
            _app.UseAuthentication();
            _app.UseMvc();

            _app.UseSpaStaticFiles();

            _app.MapWhen(
                x => !x.Request.Path.Value.StartsWith("/swagger"),
                configuration =>
                {
                    configuration.UseSpa(spa =>
                    {
                        spa.Options.SourcePath = "Frontend";
                        if (_env.IsDevelopment())
                        {
                            spa.UseProxyToSpaDevelopmentServer(DEVELOPMENT_CLIENT_URL);
                        }
                    });
                }
            );

            var address = _app.ServerFeatures.Get<IServerAddressesFeature>()?.Addresses?.FirstOrDefault();
            Log.Information("Server: {address}", address);

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings();
                settings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
                settings.Converters.Add(new StringEnumConverter());
                return settings;
            };

            return new WebStartupValidation();
        }
    }
}
