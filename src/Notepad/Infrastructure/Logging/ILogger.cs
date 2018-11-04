using System;

namespace Notepad.Infrastructure.Logging {
    public interface ILogger {
        void Informational(string formattedString, params object[] arguments);
        void Error(Exception e);
    }
}