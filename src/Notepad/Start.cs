using Notepad.Infrastructure.Container;
using Notepad.Infrastructure.Container.Windsor;
using Notepad.Presentation.Context;
using Notepad.Presentation.Views.Menu.Help;
using Notepad.Presentation.Views.Shell;

namespace Notepad {
    public class Start {
        public static void TheApplication() {
            var resolver = new WindsorDependencyRegistry();
            Resolve.InitializeWith(resolver);

            resolver.Register<WindowShell, WindowShell>();
            resolver.Register<NotepadApplicationContext, NotepadApplicationContext>();
            resolver.Register<IAboutApplicationView, AboutApplicationView>();
        }
    }
}