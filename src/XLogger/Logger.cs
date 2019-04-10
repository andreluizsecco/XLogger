using System;
using Microsoft.Extensions.Logging;
using MicrosoftLogger = Microsoft.Extensions.Logging.ILogger;

namespace XLogger
{
    public class Logger : MicrosoftLogger
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger) =>
            _logger = logger;

        /// <summary>
        /// Begins a logical operation scope.
        /// </summary>
        /// <typeparam name="TState">type of entry</typeparam>
        /// <param name="state">The identifier for the scope.</param>
        /// <returns>An IDisposable that ends the logical operation scope on dispose.</returns>
        public IDisposable BeginScope<TState>(TState state) =>
            _logger.BeginScope(state);

        /// <summary>
        /// Checks if the given logLevel is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns>true if enabled.</returns>
        public bool IsEnabled(LogLevel logLevel) =>
            _logger.Options.IsEnabled(logLevel);

        /// <summary>
        /// Checks if the logger works on-demand.
        /// </summary>
        /// <returns>true if logger is on-demand.</returns>
        public bool IsOnDemand() =>
            _logger.Options.IsOnDemand();

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TState">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="eventId">Id of the event.</param>
        /// <param name="state">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a string message of the data and exception.</param>
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel) || IsOnDemand())
                return;
            
            _logger.Write(logLevel, eventId, state, exception, formatter);
        }
    }
}