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

        public void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            foreach (var logger in _loggers)
                logger.Write(logLevel, data, exception, formatter);
        }

        public void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, data, exception, formatter);

        public void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, data, exception, formatter);

        public void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Information, data, exception, formatter);

        public void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, data, exception, formatter);

        public void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Error, data, exception, formatter);

        public void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, data, exception, formatter);
    }
}