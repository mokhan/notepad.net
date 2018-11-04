using System.Windows.Forms;
using Notepad.Infrastructure.Core;
using Notepad.Presentation.Model.Menu;

namespace Notepad.Presentation.Views.Menu.Mappers {
    public interface ISubMenuToToolStripMenuItemMapper : IMapper<ISubMenu, ToolStripMenuItem>
    {
        
    }
}