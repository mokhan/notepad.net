using System.Collections.Generic;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Presentation.Model.Menu.File {
    public class FileMenu : ISubMenu {
        private readonly IRepository<IMenuItem> repository;
        private readonly IMenuItemComparer menuItemComparer;

        public FileMenu(IRepository<IMenuItem> repository, IMenuItemComparer menuItemComparer) {
            this.repository = repository;
            this.menuItemComparer = menuItemComparer;
        }

        public IEnumerable<IMenuItem> AllMenuItems() {
            return repository
                .All()
                .ThatSatisfy(menuItem => menuItem.BelongsTo(this))
                .SortedUsing(menuItemComparer);
        }

        public string Name() {
            return MenuNames.File;
        }
    }
}