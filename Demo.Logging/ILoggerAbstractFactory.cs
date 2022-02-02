namespace Demo.Logging
{
    public interface ILoggerAbstractFactory
    {
        ILogger GetLogger();
    }
}