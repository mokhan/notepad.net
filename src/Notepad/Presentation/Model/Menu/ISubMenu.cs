using System.Collections.Generic;
using Notepad.Presentation.Model.Menu;

namespace Notepad.Presentation.Model.Menu {
    public interface ISubMenu {
        string Name();
        IEnumerable<IMenuItem> AllMenuItems();
    }
}