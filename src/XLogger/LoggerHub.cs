using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public class LoggerHub : ILoggerHub, ILoggingBuilder
    {
        private IDictionary<ILogger, ILoggerProvider> _loggerProviders;
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }

        public LoggerHub(IServiceCollection serviceCollection, Action<ILoggerHub> loggerHubOptions)
        {
            _loggerProviders = new Dictionary<ILogger, ILoggerProvider>();
            serviceCollection.AddSingleton<ILoggerHub>(this);
            Services = serviceCollection;
            loggerHubOptions.Invoke(this);
        }

        public ILoggerHub AddLogger(ILogger logger)
        {
            var loggerProvider = new LoggerProvider(logger);
            _loggerProviders.Add(logger, loggerProvider);
            this.AddProvider(loggerProvider);
            return this;
        }
    }
}