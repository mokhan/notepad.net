namespace Notepad.Presentation.Model.Menu {
    public interface IMenuItem {
        string Name();
        void Click();
        bool BelongsTo(ISubMenu menu);
    }
}