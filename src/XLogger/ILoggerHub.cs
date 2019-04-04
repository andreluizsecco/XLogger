using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public interface ILoggerHub
    {
        IServiceCollection Services { get; }
        ILoggerHub AddLogger(ILogger logger);
        
        //TODO: define the other methods to write in all registered adapters
    }
}