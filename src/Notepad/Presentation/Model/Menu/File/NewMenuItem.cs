using System;

namespace Notepad.Presentation.Model.Menu.File {
    public class NewMenuItem : IMenuItem {
        public void Click() {
            throw new NotImplementedException();
        }

        public bool BelongsTo(ISubMenu menu) {
            return menu.Name().Equals(MenuNames.File);
        }

        public string Name() {
            return "&New";
        }
    }
}