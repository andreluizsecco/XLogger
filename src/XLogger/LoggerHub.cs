using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public class LoggerHub : ILoggerHub, ILoggingBuilder
    {
        private ICollection<ILogger> _loggers;
        public IServiceCollection Services { get; }
        public IConfiguration Configuration { get; }

        public LoggerHub(IServiceCollection serviceCollection, Action<ILoggerHub> loggerHubOptions)
        {
            _loggers = new List<ILogger>();
            Configuration = GetConfiguration(serviceCollection);
            serviceCollection.AddSingleton<ILoggerHub>(this);
            Services = serviceCollection;
            loggerHubOptions.Invoke(this);
        }

        public ILoggerHub AddLogger(ILogger logger)
        {
            var loggerProvider = new LoggerProvider(logger);
            _loggers.Add(logger);
            if (!logger.Options.IsOnDemand())
                this.AddProvider(loggerProvider);
            return this;
        }

        private IConfiguration GetConfiguration(IServiceCollection serviceCollection) =>
            (IConfiguration)serviceCollection.FirstOrDefault(p => p.ServiceType == typeof(IConfiguration)).ImplementationInstance;

        public void Write<Tstate>(LogLevel logLevel, Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null)
        {
            foreach (var logger in _loggers)
                logger.Write(logLevel, state, exception, formatter);
        }

        public void Trace<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, state, exception, formatter);

        public void Debug<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, state, exception, formatter);

        public void Information<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Information, state, exception, formatter);

        public void Warning<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, state, exception, formatter);

        public void Error<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Error, state, exception, formatter);

        public void Critical<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, state, exception, formatter);
    }
}