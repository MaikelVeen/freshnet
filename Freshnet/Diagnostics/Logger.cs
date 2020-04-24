using System;
using Freshnet.Data;
using Freshnet.Models;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Freshnet.Diagnostics
{
    public class Logger : ILogger
    {
        private readonly IConfiguration Configuration;
        private readonly IDatabaseSettings DatabaseSettings;

        public Logger(IConfiguration configuration, IDatabaseSettings databaseSettings)
        {
            Configuration = configuration;
            DatabaseSettings = databaseSettings;

            bool logToFile = bool.Parse(Configuration["Logging:LogToFile"]);
            bool enrich = bool.Parse(Configuration["Logging:EnrichLogs"]);

            LoggerConfiguration loggerConfig = new LoggerConfiguration();
            loggerConfig.WriteTo.MongoDB($"{databaseSettings.ConnectionString}/{databaseSettings.DatabaseName}");

            if (logToFile)
            {
                loggerConfig.WriteTo.File($"AppData/Logs/{Configuration["Logging:FileName"]}",
                    rollingInterval: RollingInterval.Day);
            }

            if (enrich)
            {
                loggerConfig.Enrich.WithMachineName()
                    .Enrich.WithProcessId()
                    .Enrich.WithProcessName()
                    .Enrich.WithThreadId()
                    .Enrich.WithThreadName();
            }

            Log.Logger = loggerConfig.CreateLogger();
        }

        public void Info(string message)
        {
            Log.Information(message);
        }

        public void Info(string message, params object[] args)
        {
            Log.Information(message, args);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Debug(string message, params object[] args)
        {
            Log.Debug(message, args);
        }

        public void Error(Exception ex)
        {
            Error(ex, ex?.Message);
        }

        public void Error(string message, params object[] args)
        {
            Log.Error(message, args);
        }

        public void Error(Exception ex, string message, params object[] args)
        {
            Log.Error(ex, message, args);
        }

        public void Warning(ErrorResponse errorResponse)
        {
            foreach (Error error in errorResponse.Errors)
            {
                Log.Warning(error.Message);
            }
        }
    }
}