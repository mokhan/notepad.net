using Notepad.Presentation.Core;
using Notepad.Presentation.Presenters.Menu;
using Notepad.Presentation.Presenters.Shell;

namespace Notepad.Presentation.Presenters.Shell {
    public class MainShellPresenter : IMainShellPresenter {
        private readonly IApplicationController applicationController;

        public MainShellPresenter(IApplicationController applicationController) {
            this.applicationController = applicationController;
        }

        public void Initialize() {
            applicationController.Run<IMainMenuPresenter>();
        }
    }
}