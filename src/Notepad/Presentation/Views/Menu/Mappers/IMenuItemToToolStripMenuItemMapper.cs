using System.Windows.Forms;
using Notepad.Infrastructure.Core;
using Notepad.Presentation.Model.Menu;

namespace Notepad.Presentation.Views.Menu.Mappers {
    public interface IMenuItemToToolStripMenuItemMapper : IMapper<IMenuItem, ToolStripMenuItem> {}

    public class MenuItemToToolStripMenuItemMapper : IMenuItemToToolStripMenuItemMapper {
        public ToolStripMenuItem MapFrom(IMenuItem item) {
            var toolStripMenuItem = new ToolStripMenuItem(item.Name());
            toolStripMenuItem.Click += delegate { item.Click(); };
            return toolStripMenuItem;
        }
    }
}