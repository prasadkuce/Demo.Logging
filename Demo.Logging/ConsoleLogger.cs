namespace Demo.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        public override void Write(string message, Severity severity)
        {
            Console.Out.WriteLine(severity.ToString() + ": " + message);
        }
	}
}