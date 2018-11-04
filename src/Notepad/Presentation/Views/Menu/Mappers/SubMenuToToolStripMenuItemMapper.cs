using System.Windows.Forms;
using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu.Mappers;

namespace Notepad.Presentation.Views.Menu.Mappers {
    public class SubMenuToToolStripMenuItemMapper : ISubMenuToToolStripMenuItemMapper {
        private readonly IMenuItemToToolStripMenuItemMapper mapper;

        public SubMenuToToolStripMenuItemMapper(IMenuItemToToolStripMenuItemMapper mapper) {
            this.mapper = mapper;
        }

        public ToolStripMenuItem MapFrom(ISubMenu item) {
            var toolStripMenuItem = new ToolStripMenuItem(item.Name());
            foreach (var menuItem in item.AllMenuItems()) {
                toolStripMenuItem.DropDownItems.Add(mapper.MapFrom(menuItem));
            }
            return toolStripMenuItem;
        }
    }
}