namespace Demo.Logging
{
    public interface ILogger
    {
        void Log(string content, Severity severity = Severity.Verbose);

        void LogFormat(string formatStr, Severity severity, params object[] args);

        void Write(string message, Severity severity);
    }

    public abstract class LoggerBase : ILogger
    {
        public void LogFormat(string formatStr, Severity severity, params object[] args)
        {
            string message = String.Empty;
            if(!String.IsNullOrEmpty(formatStr) && args != null && args.Length > 0)
                message = String.Format(formatStr, args);
            Write(message, severity);
        }
        public abstract void Write(string message, Severity severity);

        public void Log(string content, Severity severity = Severity.Verbose)
        {
            Write(content, severity);
        }
    }
}
