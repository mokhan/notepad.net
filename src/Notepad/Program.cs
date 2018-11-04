using System;
using System.Windows.Forms;
using Notepad.Infrastructure.Container;
using Notepad.Infrastructure.Extensions;
using Notepad.Presentation.Context;

namespace Notepad {
    internal static class Program {
        [STAThread]
        private static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, e) => e.Exception.LogError();
            try {
                Start.TheApplication();
                Application.Run(Resolve.DependencyFor<NotepadApplicationContext>());
            }
            catch (Exception e1) {
                e1.LogError();
            }
        }
    }
}