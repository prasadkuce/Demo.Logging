namespace Demo.Logging
{
    public class DebugLogger : LoggerBase
    {
        public override void Write(string message, Severity severity)
        {
            System.Diagnostics.Debug.WriteLine(severity.ToString() + ": " + message);
        }
    }

    public class DebugLoggerFactory : ILoggerAbstractFactory
    {
        public ILogger GetLogger()
        {
            return new DebugLogger();
        }
    }

}