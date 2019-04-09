using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace XLogger.Options
{
    public interface ILoggerOptions
    {
        LogLevel LogLevel { get; set; }
        bool OnDemand { get; set; }

        bool IsEnabled(LogLevel logLevel);

        bool IsOnDemand();

        void ReadFromConfiguration(IConfiguration configuration);
    }
}