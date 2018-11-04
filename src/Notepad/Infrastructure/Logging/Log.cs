using Notepad.Infrastructure.Container;
using Notepad.Infrastructure.Logging.Log4NetLogging;

namespace Notepad.Infrastructure.Logging {
    public static class Log {
        public static ILogger For<T>(T typeToCreateLoggerFor) {
            try {
                return Resolve.DependencyFor<ILogFactory>().CreateFor(typeof (T));
            }
            catch {
                return new Log4NetLogFactory().CreateFor(typeof (T));
            }
        }
    }
}