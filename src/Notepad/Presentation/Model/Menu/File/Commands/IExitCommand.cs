using Notepad.Infrastructure.Core;
using Notepad.Infrastructure.System;

namespace Notepad.Presentation.Model.Menu.File.Commands {
    public interface IExitCommand : ICommand {}

    public class ExitCommand : IExitCommand {
        private readonly IApplicationEnvironment application;

        public ExitCommand(IApplicationEnvironment application) {
            this.application = application;
        }

        public void Execute() {
            application.ShutDown();
        }
    }
}