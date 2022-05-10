using System;
using Microsoft.Extensions.Logging;

namespace BP.API.Loging
{
    public class MyCustomLoggerFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {
            
        }
    }

    public class MyCustomLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logMsg = formatter(state, exception);

            logMsg = $"[{DateTime.UtcNow}] -{logMsg}";

            Console.WriteLine(logMsg);
        }
    }
}
