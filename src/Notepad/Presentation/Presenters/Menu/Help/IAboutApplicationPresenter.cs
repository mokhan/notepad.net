using Notepad.Presentation.Core;
using Notepad.Presentation.Views.Menu.Help;

namespace Notepad.Presentation.Presenters.Menu.Help {
    public interface IAboutApplicationPresenter : IPresenter {}

    public class AboutApplicationPresenter : IAboutApplicationPresenter {
        private readonly IAboutApplicationView view;

        public AboutApplicationPresenter(IAboutApplicationView view) {
            this.view = view;
        }

        public void Initialize() {
            view.Display();
        }
    }
}