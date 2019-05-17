namespace XLogger.Models
{
    public class LogException
    {
        public int HResult { get; private set; }
        public string HelpLink { get; private set; }
        public LogInnerException InnerException { get; private set; }
        public string Message { get; private set; }
        public string Source { get; private set; }
        public string StackTrace { get; private set; }
    }

    public class LogInnerException
    {
        public int? HResult { get; private set; }
        public string HelpLink { get; private set; }
        public string Message { get; private set; }
        public string Source { get; private set; }
        public string StackTrace { get; private set; }
    }
}