using System;

namespace Notepad.Infrastructure.System {
    public interface IApplicationEnvironment {
        void ShutDown();
    }

    public class ApplicationEnvironment : IApplicationEnvironment {
        public void ShutDown() {
            Environment.Exit(Environment.ExitCode);
        }
    }
}