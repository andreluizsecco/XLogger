using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public class LoggerHub : ILoggerHub, ILoggingBuilder
    {
        private ICollection<ILogger> _loggers;

        /// <summary>
        /// Specifies the contract for a collection of service descriptors.
        /// </summary>
        public IServiceCollection Services { get; }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        public IConfiguration Configuration { get; }

        public LoggerHub()
        {
            _loggers = new List<ILogger>();
            Services = new ServiceCollection();
        }
        
        public LoggerHub(IServiceCollection serviceCollection, Action<ILoggerHub> loggerHubOptions) : this()
        {
            Configuration = GetConfiguration(serviceCollection);
            serviceCollection.AddSingleton<ILoggerHub>(this);
            Services = serviceCollection;
            loggerHubOptions.Invoke(this);
        }

        /// <summary>
        /// Add and register new logger in the hub.
        /// </summary>
        /// <param name="logger">A Xlogger adapter instance.</param>
        /// <returns>Hub with new logger registered.</returns>
        public ILoggerHub AddLogger(ILogger logger)
        {
            var loggerProvider = new LoggerProvider(logger);
            _loggers.Add(logger);
            if (!logger.Options.IsOnDemand())
                this.AddProvider(loggerProvider);
            return this;
        }

        private IConfiguration GetConfiguration(IServiceCollection serviceCollection)
        {
            var configurationService = serviceCollection.FirstOrDefault(p => p.ServiceType == typeof(IConfiguration));
            var configuration = configurationService.ImplementationInstance ??
                                configurationService.ImplementationFactory.Invoke(serviceCollection.BuildServiceProvider());
            
            return (IConfiguration)configuration;
        }

        // private IConfiguration GetConfiguration(IServiceCollection serviceCollection) =>
        //     (IConfiguration)serviceCollection.FirstOrDefault(p => p.ServiceType == typeof(IConfiguration))?.ImplementationInstance;

        /// <summary>
        /// Writes a log entry to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            foreach (var logger in _loggers)
                logger.Write(logLevel, data, exception, formatter);
        }

        /// <summary>
        /// Writes a log entry to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task WriteAsync<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null)
        {
            foreach (var logger in _loggers)
                await logger.WriteAsync(logLevel, data, exception, formatter);
        }

        /// <summary>
        /// Writes a log entry on trace level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Trace, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on trace level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task TraceAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Trace, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on debug level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Debug, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on debug level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task DebugAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Debug, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on information level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Information, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on information level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task InformationAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Information, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on warning level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Warning, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on warning level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task WarningAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Warning, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on error level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Error, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on error level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task ErrorAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Error, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on critical level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            Write(LogLevel.Critical, data, exception, formatter);

        /// <summary>
        /// Writes a log entry on critical level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        public async Task CriticalAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null) =>
            await WriteAsync(LogLevel.Critical, data, exception, formatter);
    }
}