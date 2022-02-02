namespace Demo.Logging
{
    public class DefaultLoggerFactory : ILoggerAbstractFactory
    {
        public ILogger GetLogger()
        {
            return new AggregateLogger(typeof(ConsoleLogger), typeof(DebugLogger));
        }
    }
}