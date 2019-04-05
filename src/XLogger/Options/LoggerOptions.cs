using Microsoft.Extensions.Logging;

namespace XLogger.Options
{
    public class LoggerOptions : ILoggerOptions
    {
        public LogLevel LogLevel { get; set; }
        public bool OnDemand { get; set; }
        public string DateTimeFormat { get; set; }

        public LoggerOptions()
        {
            LogLevel = LogLevel.Information;
            OnDemand = false;
            DateTimeFormat = null;
        }

        public bool IsEnabled(LogLevel logLevel) =>
            LogLevel <= logLevel;

        public bool IsOnDemand() => OnDemand;
    }
}