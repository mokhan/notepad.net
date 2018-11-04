using System.Windows.Forms;

namespace Notepad.Presentation.Views.Shell {
    public partial class WindowShell : Form {
        public WindowShell() {
            InitializeComponent();
        }

        public MenuStrip MenuStrip() {
            return uxMainMenuStrip;
        }
    }
}