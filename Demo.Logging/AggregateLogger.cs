namespace Demo.Logging
{
    public class AggregateLogger : LoggerBase
    {
        private readonly List<ILogger> _loggers = new List<ILogger>();

        public AggregateLogger(params Type[] loggerTypes)
        {
            if (loggerTypes.Length == 0)
                throw new ArgumentException("No logger types provided", "loggerTypes");

            var invalidTypes = loggerTypes
                .Distinct()
                .Where(type => !typeof(ILogger).IsAssignableFrom(type))
                .ToList();

            if (invalidTypes.Any())
                throw new ArgumentException("Types do not implement ILogger");

            _loggers = loggerTypes
                .Distinct()
                .Select(Activator.CreateInstance)
                .Cast<ILogger>().ToList();
        }

        public override void Write(string message, Severity severity)
        {
            _loggers.ForEach(logger => logger.Write(message, severity));
        }
    }
}