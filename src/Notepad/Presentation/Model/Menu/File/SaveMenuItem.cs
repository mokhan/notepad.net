using Notepad.Presentation.Model.Menu.File.Commands;

namespace Notepad.Presentation.Model.Menu.File {
    public class SaveMenuItem : IMenuItem {
        private readonly ISaveCommand saveCommand;

        public SaveMenuItem(ISaveCommand saveCommand) {
            this.saveCommand = saveCommand;
        }

        public bool BelongsTo(ISubMenu menu) {
            return menu.Name().Equals(MenuNames.File);
        }

        public void Click() {
            saveCommand.Execute();
        }

        public string Name() {
            return "&Save";
        }
    }
}