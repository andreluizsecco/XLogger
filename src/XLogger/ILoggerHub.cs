using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public interface ILoggerHub
    {
        IServiceCollection Services { get; }
        IConfiguration Configuration { get; }
        ILoggerHub AddLogger(ILogger logger);
        
        void Write<Tstate>(LogLevel logLevel, Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
                
        void Trace<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
        
        void Debug<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Information<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Warning<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
        
        void Error<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);

        void Critical<Tstate>(Tstate state, Exception exception = null, Func<Tstate, Exception, object> formatter = null);
    }
}