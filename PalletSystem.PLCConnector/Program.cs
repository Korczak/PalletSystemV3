﻿using Newtonsoft.Json;
using PalletSystem.PLCConnector.Client;
using PeterKottas.DotNetCore.WindowsService;
using S7.Net;
using Serilog;
using System;
using System.IO;
using System.Text;

namespace PalletSystem.PLCConnector
{
    class Program
    {
        static void Main(string[] args)
        {
            var Config = GetConfig();

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Area", "Device Connector")
                .MinimumLevel.Is(Serilog.Events.LogEventLevel.Verbose)
                .WriteTo.Console(
                        restrictedToMinimumLevel: Config.ConsoleLogLevel)
                .WriteTo.RollingFile(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "plc-connector-{Date}.log"),
                        restrictedToMinimumLevel: Config.ConsoleLogLevel,
                        shared: true)
                .CreateLogger();

            ConnectorClient webService = null;
            Connector connector = new Connector("Connector1");
            Config webConfig = null;

            try
            {
                webConfig = GetConfig();
                webService = new ConnectorClient(webConfig.WebApiUrl, new System.Net.Http.HttpClient());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Configuration error occured");
                return;
            }

            ServiceRunner<ServiceConnector>.Run(config =>
            {
                var name = "Pallet System PLC Connector";
                config.SetName("PalletSystem.PLCConnector");
                config.SetDisplayName(name);
                config.SetDescription("Provides connectivity between the PalletSystem and PLC");
                config.Service(serviceConfig =>
                {
                    serviceConfig.ServiceFactory((svc, extraArguments) =>
                    {
                        return new ServiceConnector(connector, Config, webService);
                    });
                    serviceConfig.OnStart((service, extraArguments) =>
                    {
                        service.Start();
                        Log.Information("Service {Name} started", name);
                    });

                    serviceConfig.OnStop(service =>
                    {
                        service?.Stop();
                        Log.Information("Service {Name} stopped", name);
                    });

                    serviceConfig.OnInstall(service =>
                    {
                        Log.Information("Service {Name} installed", name);
                    });

                    serviceConfig.OnUnInstall(service =>
                    {
                        Log.Information("Service {Name} uninstalled", name);
                    });

                    serviceConfig.OnPause(service =>
                    {
                        Log.Information("Service {Name} paused", name);
                    });

                    serviceConfig.OnContinue(service =>
                    {
                        Log.Information("Service {Name} continued", name);
                    });

                    serviceConfig.OnError(e =>
                    {
                        Log.Error(e, "Service {Name} errored with exception", name);
                    });
                });
            });
        }
        public static Config GetConfig()
        {
            var projectPath = AppDomain.CurrentDomain.BaseDirectory;
            var configPath = Path.Combine(projectPath, "appsettings.json");

            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException($"Configuration file not found in: {configPath}");
            }

            var content = File.ReadAllText(configPath, Encoding.UTF8);
            var config = JsonConvert.DeserializeObject<Config>(content);
            return config;
        }
    }
}