using System.Collections.Generic;

namespace Notepad.Presentation.Model.Menu {
    public interface IMenuItemComparer : IComparer<IMenuItem> {}

    public class MenuItemComparer : IMenuItemComparer {
        private IList<string> rankedMenuItems;

        public MenuItemComparer() {
            rankedMenuItems = new List<string> {
                                                   MenuItemNames.New,
                                                   MenuItemNames.Save,
                                                   MenuItemNames.SaveAs,
                                                   MenuItemNames.Exit,
                                                   MenuItemNames.About
                                               };
        }

        public int Compare(IMenuItem x, IMenuItem y) {
            return rankedMenuItems.IndexOf(x.Name()).CompareTo(rankedMenuItems.IndexOf(y.Name()));
        }
    }
}