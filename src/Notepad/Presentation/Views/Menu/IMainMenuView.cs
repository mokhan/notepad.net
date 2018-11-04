using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu.Mappers;
using Notepad.Presentation.Views.Shell;

namespace Notepad.Presentation.Views.Menu {
    public interface IMainMenuView {
        void Add(ISubMenu menuToAddToTheMainMenu);
    }

    public class MainMenuView : IMainMenuView {
        private readonly ISubMenuToToolStripMenuItemMapper mapper;
        private readonly WindowShell mainShell;

        public MainMenuView(WindowShell mainShell, ISubMenuToToolStripMenuItemMapper mapper) {
            this.mapper = mapper;
            this.mainShell = mainShell;
        }

        public void Add(ISubMenu menuToAddToTheMainMenu) {
            mainShell.MenuStrip().Items.Add(mapper.MapFrom(menuToAddToTheMainMenu));
        }
    }
}