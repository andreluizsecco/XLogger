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
        
        void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
                
        void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
        
        void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
        
        void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);
    }
}