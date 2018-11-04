using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Extensions;
using Notepad.Presentation.Core;
using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu;

namespace Notepad.Presentation.Presenters.Menu {
    public interface IMainMenuPresenter : IPresenter {}

    public class MainMenuPresenter : IMainMenuPresenter {
        private readonly IMainMenuView mainMenu;
        private readonly IRepository<ISubMenu> repository;
        private readonly ISubMenuItemComparer comparer;

        public MainMenuPresenter(IMainMenuView mainMenu,
                                 IRepository<ISubMenu> repository,
                                 ISubMenuItemComparer comparer) {
            this.mainMenu = mainMenu;
            this.repository = repository;
            this.comparer = comparer;
        }

        public void Initialize() {
            foreach (var subMenuToAddToMainMenu in repository.All().SortedUsing(comparer)) {
                mainMenu.Add(subMenuToAddToMainMenu);
            }
        }
    }
}