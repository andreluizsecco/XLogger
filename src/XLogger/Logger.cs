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

        public IDisposable BeginScope<TState>(TState state) =>
            _logger.BeginScope(state);

        public bool IsEnabled(LogLevel logLevel) =>
            _logger.IsEnabled(logLevel);

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel) || _logger.IsOnDemand())
                return;
            
            _logger.Write(logLevel, eventId, state, exception, formatter);
        }
    }
}