﻿using PalletSystem.Core.Configuration;
using Serilog;
using System;
using System.IO;

namespace PalletSystem.Core.Logging
{
    public class LoggingStartup : IStartupStep
    {
        private readonly Config _config;
        private readonly LoggingPaths _paths;

        public LoggingStartup(Config config, LoggingPaths paths)
        {
            _config = config;
            _paths = paths;
        }

        public IStartupValidation Configure()
        {
            var logPath = Path.Combine(_paths.LoggerPath, $"logger.log");
            File.Create(logPath);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(_config.LogLevel)
                .Enrich.FromLogContext()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}][{Area}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(logPath, outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}][{Area}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            Log.Information($"Logger configured. Log level: {_config.LogLevel}");

            return new LoggingValidation();
        }


    }
}