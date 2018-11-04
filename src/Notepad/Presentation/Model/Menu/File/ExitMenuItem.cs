using Notepad.Presentation.Model.Menu.File.Commands;

namespace Notepad.Presentation.Model.Menu.File {
    public class ExitMenuItem : IMenuItem {
        private readonly IExitCommand exitCommand;

        public ExitMenuItem(IExitCommand exitCommand) {
            this.exitCommand = exitCommand;
        }

        public string Name() {
            return "E&xit";
        }

        public void Click() {
            exitCommand.Execute();
        }

        public bool BelongsTo(ISubMenu menu) {
            return menu.Name().Equals(MenuNames.File);
        }
    }
}