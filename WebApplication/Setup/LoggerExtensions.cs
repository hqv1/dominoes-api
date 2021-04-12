using Microsoft.Extensions.Logging;

namespace Hqv.Dominoes.WebApplication.Setup
{
    public static class LoggerExtensions
    {
        public static void LogDebugOrElevate(this ILogger logger, bool elevate, string message, params object[] args)
        {
            var logLevel = elevate ? LogLevel.Information : LogLevel.Debug;
            logger.Log(logLevel, message, args);
        }
    }
}