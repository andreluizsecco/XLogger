using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger
{
    public interface ILogger : ILoggerBase, IDisposable
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
    }
}