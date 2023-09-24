using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace db_cp.Logger
{
    public class Logger : ILogger
    {
        private readonly string categoryName;
        private readonly LogLevel logLevel;
        private readonly string logFormat;
        private readonly TimeZoneInfo timeZone;
        private readonly string logFilePath;

        public Logger(string categoryName, LogLevel logLevel, string logFormat, TimeZoneInfo timeZone, string logFilePath)
        {
            this.categoryName = categoryName;
            this.logLevel = logLevel;
            this.logFormat = logFormat;
            this.timeZone = timeZone;
            this.logFilePath = logFilePath;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null; // Not implemented
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= this.logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var logMessage = string.Format(logFormat, timeZone, DateTime.Now, logLevel, categoryName, formatter(state, exception));
            Console.WriteLine(logMessage);

            WriteToFile(logMessage);
        }

        private void WriteToFile(string message)
        {
            try
            {
                using (var writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to log file: {ex.Message}");
            }
        }
    }
}