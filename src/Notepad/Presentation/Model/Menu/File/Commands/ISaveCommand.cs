using Notepad.Infrastructure.Core;
using Notepad.Presentation.Core;
using Notepad.Presentation.Presenters.Menu.File;
using Notepad.Tasks;

namespace Notepad.Presentation.Model.Menu.File.Commands {
    public interface ISaveCommand : ICommand {}

    public class SaveCommand : ISaveCommand {
        private readonly IApplicationController controller;
        private readonly IDocumentTasks tasks;

        public SaveCommand(IApplicationController controller, IDocumentTasks tasks) {
            this.controller = controller;
            this.tasks = tasks;
        }

        public void Execute() {
            if (!tasks.HasAPathToSaveToBeenSpecified()) {
                controller.Run<ISaveAsPresenter>();
            }
            else {
                tasks.SaveTheActiveDocument();
            }
        }
    }
}