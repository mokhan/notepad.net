using Notepad.Presentation.Presenters.Commands;
using Notepad.Presentation.Presenters.Menu.File;

namespace Notepad.Presentation.Model.Menu.File {
    public class SaveAsMenuItem : IMenuItem {
        private readonly IRunPresenterCommand<ISaveAsPresenter> saveAsCommand;

        public SaveAsMenuItem(IRunPresenterCommand<ISaveAsPresenter> saveAsCommand) {
            this.saveAsCommand = saveAsCommand;
        }

        public string Name() {
            return "Save &As...";
        }

        public void Click() {
            saveAsCommand.Execute();
        }

        public bool BelongsTo(ISubMenu menu) {
            return menu.Name().Equals(MenuNames.File);
        }
    }
}