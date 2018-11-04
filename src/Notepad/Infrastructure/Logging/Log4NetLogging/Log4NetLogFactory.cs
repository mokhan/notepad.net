using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Notepad.Infrastructure.Logging.Log4NetLogging {
    public class Log4NetLogFactory : ILogFactory {
        public Log4NetLogFactory() {
            XmlConfigurator.Configure(PathToConfigFile());
        }

        public ILogger CreateFor(Type typeToCreateLoggerFor) {
            return new Log4NetLogger(LogManager.GetLogger(typeToCreateLoggerFor));
        }

        private FileInfo PathToConfigFile() {
            return new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config.xml"));
        }
    }
}