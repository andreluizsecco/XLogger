using System;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger
{
    public interface ILogger : IDisposable
    {
        ILoggerOptions Options { get; }

        IDisposable BeginScope<TState>(TState state);

        void Write<TData>(LogLevel logLevel, EventId eventId, TData data, Exception exception, Func<TData, Exception, string> formatter);

        void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
                
        void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
        
        void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
        
        void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
    }
}