using System;
using Microsoft.Extensions.Logging;

namespace XLogger.Models
{
    public class Log<TData>
    {
        public DateTime DateTime { get; private set; }
        public LogLevel LogLevel { get; private set; }
        public TData Data { get; private set; }
        public LogException Exception { get; private set; }
    }
}