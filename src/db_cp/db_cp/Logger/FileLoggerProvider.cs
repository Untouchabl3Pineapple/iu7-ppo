using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace db_cp.Logger
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IConfiguration configuration;

        public LoggerProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ILogger CreateLogger(string categoryName)
        {
            var logLevel = GetLogLevel();
            var logFormat = GetLogFormat();
            var timeZone = GetTimeZone();
            var logFilePath = GetLogFilePath();

            return new Logger(categoryName, logLevel, logFormat, timeZone, logFilePath);
        }

        public void Dispose()
        {
        }

        private LogLevel GetLogLevel()
        {
            var logLevel = configuration["LogLevel"];
            return Enum.Parse<LogLevel>(logLevel);
        }

        private string GetLogFormat()
        {
            return configuration["LogFormat"];
        }

        private TimeZoneInfo GetTimeZone()
        {
            var timeZoneId = configuration["TimeZone"];
            return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
        }

        private string GetLogFilePath()
        {
            return configuration["LogFilePath"];
        }
    }
}