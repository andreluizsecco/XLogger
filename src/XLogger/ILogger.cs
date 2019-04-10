using System;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger
{
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// The current logger options.
        /// </summary>
        ILoggerOptions Options { get; }

        IDisposable BeginScope<TData>(TData data);

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a string message of the data and exception.</param>
        void Write<TData>(LogLevel logLevel, EventId eventId, TData data, Exception exception, Func<TData, Exception, string> formatter);

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on trace level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on debug level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on information level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on warning level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on error level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on critical level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
    }
}