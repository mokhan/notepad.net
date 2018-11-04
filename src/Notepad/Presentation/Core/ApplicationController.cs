namespace Notepad.Presentation.Core {
    public class ApplicationController : IApplicationController {
        private readonly IPresenterRegistry registeredPresenters;

        public ApplicationController(IPresenterRegistry presenterRegistry) {
            registeredPresenters = presenterRegistry;
        }

        public void Run<Presenter>() where Presenter : IPresenter {
            registeredPresenters.FindAnImplementationOf<Presenter>().Initialize();
        }
    }
}