namespace Notepad.Presentation.Core {
    public interface IApplicationController {
        void Run<Presenter>() where Presenter : IPresenter;
    }
}