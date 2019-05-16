using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace XLogger
{
    public interface ILoggerBase
    {
        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Write<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="logLevel">Entry will be written on this level.</param>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task WriteAsync<TData>(LogLevel logLevel, TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on trace level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Trace<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on trace level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task TraceAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on debug level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Debug<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on debug level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task DebugAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on information level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Information<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on information level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task InformationAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on warning level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Warning<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on warning level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task WarningAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on error level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Error<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on error level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task ErrorAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on critical level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        void Critical<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);

        /// <summary>
        /// Writes a log entry on critical level.
        /// </summary>
        /// <typeparam name="TData">type of entry.</typeparam>
        /// <param name="data">The entry to be written. Can be also an object.</param>
        /// <param name="exception">The exception related to this entry.</param>
        /// <param name="formatter">Function to create a custom object of the data and exception.</param>
        Task CriticalAsync<TData>(TData data, Exception exception = null, Func<TData, Exception, object> formatter = null);        
    }
}