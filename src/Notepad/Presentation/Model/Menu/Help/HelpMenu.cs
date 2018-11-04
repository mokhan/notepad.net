using System.Collections.Generic;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Presentation.Model.Menu.Help {
    public class HelpMenu : ISubMenu {
        private readonly IRepository<IMenuItem> menuItems;

        public HelpMenu(IRepository<IMenuItem> repository) {
            menuItems = repository;
        }

        public IEnumerable<IMenuItem> AllMenuItems() {
            return menuItems.All().ThatSatisfy(m => m.BelongsTo(this));
        }

        public string Name() {
            return MenuNames.Help;
        }
    }
}