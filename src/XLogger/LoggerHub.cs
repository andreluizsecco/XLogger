using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public class LoggerHub : ILoggerHub, ILoggingBuilder
    {
        private IDictionary<ILogger, ILoggerProvider> _loggerProviders;
        public IServiceCollection Services { get; }

        public LoggerHub(IServiceCollection serviceCollection)
        {
            _loggerProviders = new Dictionary<ILogger, ILoggerProvider>();
            serviceCollection.AddSingleton<ILoggerHub>(this);
            Services = serviceCollection;
        }

        public ILoggerHub AddLogger(ILogger logger)
        {
            var loggerProvider = new LoggerProvider(logger);
            _loggerProviders.Add(logger, loggerProvider);
            this.AddProvider(loggerProvider);
            return this;
        }

        public void LogAll()
        {
            foreach (var logger in _loggerProviders)
                logger.Key.Error("ERROOO EM TUUUDOOOOO");
        }
    }
}