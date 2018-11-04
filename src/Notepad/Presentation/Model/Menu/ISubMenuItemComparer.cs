using System.Collections.Generic;

namespace Notepad.Presentation.Model.Menu {
    public interface ISubMenuItemComparer : IComparer<ISubMenu> {}

    public class SubMenuItemComparer : ISubMenuItemComparer {
        private List<string> rankings;

        public SubMenuItemComparer() {
            rankings = new List<string> {
                                            MenuNames.File,
                                            MenuNames.Help
                                        };
        }

        public int Compare(ISubMenu x, ISubMenu y) {
            return rankings.IndexOf(x.Name()).CompareTo(rankings.IndexOf(y.Name()));
        }
    }
}