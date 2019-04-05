using System;
using Microsoft.Extensions.Logging;
using XLogger.Options;

namespace XLogger
{
    public interface ILogger : IDisposable
    {
        ILoggerOptions Options { get; }

        IDisposable BeginScope<TState>(TState state);

        void Write<Tstate>(LogLevel logLevel, EventId eventId, Tstate state, Exception exception, Func<Tstate, Exception, string> formatter);
                
        void Trace<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
        
        void Debug<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Information<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Warning<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
        
        void Error<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Critical<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
    }
}