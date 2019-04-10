using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XLogger.Options
{
    public abstract class LoggerOptions : ILoggerOptions
    {
        /// <summary>
        /// Minimum logging severity level.
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// Logger will work only on demand
        /// </summary>
        public bool OnDemand { get; set; }

        /// <summary>
        /// Construct a <see cref="LoggerOptions"/>.
        /// By default, the <see cref="LogLevel"/> property is set to 'Information' level and <see cref="OnDemand"> property is set to false.
        /// </summary>
        public LoggerOptions()
        {
            LogLevel = LogLevel.Information;
            OnDemand = false;
        }

        /// <summary>
        /// Checks if the given logLevel is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns>true if enabled.</returns>
        public bool IsEnabled(LogLevel logLevel) =>
            LogLevel <= logLevel;

        /// <summary>
        /// Checks if the logger works on-demand.
        /// </summary>
        /// <returns>true if logger is on-demand.</returns>
        public bool IsOnDemand() => OnDemand;

        /// <summary>
        /// Set the logger options based on the key/value application configuration properties.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties. See <see cref="IConfiguration"/>.</param>
        public abstract void ReadFromConfiguration(IConfiguration configuration);
    }
}