using Notepad.Infrastructure.Container;

namespace Notepad.Presentation.Core {
    public interface IPresenterRegistry {
        Presenter FindAnImplementationOf<Presenter>() where Presenter : IPresenter;
    }

    public class RegisteredPresenter : IPresenterRegistry {
        public Presenter FindAnImplementationOf<Presenter>() where Presenter : IPresenter {
            return Resolve.DependencyFor<Presenter>();
        }
    }
}