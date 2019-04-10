using Microsoft.Extensions.Logging;
using MicrosoftLogger = Microsoft.Extensions.Logging.ILogger;

namespace XLogger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Construct a <see cref="LoggerProvider"/>.
        /// </summary>
        /// <param name="logger">A XLogger adapter instance to write events.</param>
        public LoggerProvider(ILogger logger) =>
            _logger = logger;

        /// <summary>
        /// Create a Logger instance with your respective XLogger adapter.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public MicrosoftLogger CreateLogger(string categoryName) =>
            new Logger(_logger);

        public void Dispose() =>
            _logger.Dispose();
    }
}