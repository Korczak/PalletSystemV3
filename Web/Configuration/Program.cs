using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Web.Configuration;

namespace Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString(), "Startup error");
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .RunWindowServiceIfWindows()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static IHostBuilder RunWindowServiceIfWindows(this IHostBuilder host)
        {
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                host.UseWindowsService()
                    .ConfigureServices(services =>
                        services.AddHostedService<Worker>());
            }

            return host;
        }
    }
}
