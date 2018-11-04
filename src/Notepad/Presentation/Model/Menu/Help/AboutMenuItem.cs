using Notepad.Presentation.Presenters.Commands;
using Notepad.Presentation.Presenters.Menu.Help;

namespace Notepad.Presentation.Model.Menu.Help {
    public class AboutMenuItem : IMenuItem {
        private readonly IRunPresenterCommand<IAboutApplicationPresenter> displayAboutCommand;

        public AboutMenuItem(IRunPresenterCommand<IAboutApplicationPresenter> displayAboutCommand) {
            this.displayAboutCommand = displayAboutCommand;
        }

        public bool BelongsTo(ISubMenu menu) {
            return menu.Name().Equals(MenuNames.Help);
        }

        public void Click() {
            displayAboutCommand.Execute();
        }

        public string Name() {
            return MenuItemNames.About;
        }
    }
}