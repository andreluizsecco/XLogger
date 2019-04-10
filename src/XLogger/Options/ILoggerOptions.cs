using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XLogger.Options
{
    public interface ILoggerOptions
    {
        /// <summary>
        /// Minimum logging severity level.
        /// </summary>
        LogLevel LogLevel { get; set; }

        /// <summary>
        /// Logger will work only on demand
        /// </summary>
        bool OnDemand { get; set; }

        /// <summary>
        /// Checks if the given logLevel is enabled.
        /// </summary>
        /// <param name="logLevel">level to be checked.</param>
        /// <returns>true if enabled.</returns>
        bool IsEnabled(LogLevel logLevel);

        /// <summary>
        /// Checks if the logger works on-demand.
        /// </summary>
        /// <returns>true if logger is on-demand.</returns>
        bool IsOnDemand();

        /// <summary>
        /// Set the logger options based on the key/value application configuration properties.
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties. See <see cref="IConfiguration"/>.</param>
        void ReadFromConfiguration(IConfiguration configuration);
    }
}