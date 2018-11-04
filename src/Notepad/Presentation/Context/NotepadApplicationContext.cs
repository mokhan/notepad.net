using System.Windows.Forms;
using Notepad.Presentation.Core;
using Notepad.Presentation.Model.Menu.File.Commands;
using Notepad.Presentation.Presenters.Shell;
using Notepad.Presentation.Views.Shell;

namespace Notepad.Presentation.Context {
    public class NotepadApplicationContext : ApplicationContext {
        public NotepadApplicationContext(
            WindowShell shellView,
            IExitCommand exitCommand,
            IApplicationController applicationController) {
            shellView.Closed += delegate { exitCommand.Execute(); };
            applicationController.Run<IMainShellPresenter>();
            MainForm = shellView;
        }
    }
}