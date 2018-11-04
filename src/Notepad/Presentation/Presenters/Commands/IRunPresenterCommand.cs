using Notepad.Infrastructure.Core;
using Notepad.Presentation.Core;

namespace Notepad.Presentation.Presenters.Commands {
    public interface IRunPresenterCommand<Presenter> : ICommand where Presenter : IPresenter {}

    public class RunPresenterCommand<Presenter> : IRunPresenterCommand<Presenter> where Presenter : IPresenter {
        private readonly IApplicationController applicationController;

        public RunPresenterCommand(IApplicationController applicationController) {
            this.applicationController = applicationController;
        }

        public void Execute() {
            applicationController.Run<Presenter>();
        }
    }
}