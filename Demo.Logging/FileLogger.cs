namespace Demo.Logging
{
    public class FileLogger : LoggerBase
    {
        public override void Write(string message, Severity severity)
        {
            string path = string.Empty;
            path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (!File.Exists(path + "\\" + "log.txt"))
            {
                using var _ = File.Create(path + "\\" + "log.txt");
            }

            try
            {
                using StreamWriter w = File.AppendText(path + "\\" + "log.txt");
                AppendLog(message, severity, w);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void AppendLog(string logMessage, Severity severity, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{DateTime.Now:yyyy-MM-dd hh:mm:ss tt} : {severity} | {logMessage}");
            }
            catch (Exception ex)
            {
            }
        }
    }
    public class FileLoggerFactory : ILoggerAbstractFactory
    {
        public ILogger GetLogger()
        {
            return new FileLogger();
        }
    }
}
