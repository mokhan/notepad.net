using System;
using log4net;

namespace Notepad.Infrastructure.Logging.Log4NetLogging {
    public class Log4NetLogger : ILogger {
        private readonly ILog log;

        public Log4NetLogger(ILog log) {
            this.log = log;
        }

        public void Informational(string formattedString, params object[] arguments) {
            log.InfoFormat(formattedString, arguments);
        }

        public void Error(Exception e) {
            log.Error(e.ToString());
        }
    }
}