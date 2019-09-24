using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace XLogger
{
    public interface ILoggerHub : ILoggerBase
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
    }
}