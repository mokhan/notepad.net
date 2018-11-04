using System;

namespace Notepad.Infrastructure.Logging {
    public interface ILogFactory {
        ILogger CreateFor(Type typeToCreateLoggerFor);
    }
}