using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public interface ILoggerHub
    {
        /// <summary>
        /// Specifies the contract for a collection of service descriptors.
        /// </summary>
        IServiceCollection Services { get; }

        /// <summary>
        /// Represents a set of key/value application configuration properties.
        /// </summary>
        IConfiguration Configuration { get; }

        /// <summary>
        /// Add and register new logger in the hub.
        /// </summary>
        /// <param name="logger">A Xlogger adapter instance.</param>
        /// <returns>Hub with new logger registered.</returns>
        ILoggerHub AddLogger(ILogger logger);

        /// <summary>
        /// Writes a log entry to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on trace level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on debug level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on information level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on warning level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on error level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on critical level to all loggers registered.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
    }
}