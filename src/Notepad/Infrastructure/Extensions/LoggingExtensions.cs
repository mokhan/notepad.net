using System;
using Notepad.Infrastructure.Logging;

namespace Notepad.Infrastructure.Extensions {
    public static class LoggingExtensions {
        public static void LogError(this Exception errorToLog) {
            Log.For(errorToLog).Error(errorToLog);
        }

        public static void LogInformational<T>(
            this T typeToCreateLoggerFor,
            string formattedMessage,
            params object[] arguments) {
            Log.For(typeToCreateLoggerFor).Informational(formattedMessage, arguments);
        }
    }
}