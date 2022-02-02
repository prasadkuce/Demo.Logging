namespace Demo.Logging
{
    public class TraceLogger : LoggerBase
    {
        public override void Write(string message, Severity severity)
        {
            System.Diagnostics.Trace.WriteLine(severity.ToString() + ": " + message);
        }
    }
}