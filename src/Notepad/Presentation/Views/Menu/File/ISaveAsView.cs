using System.Windows.Forms;
using Notepad.Presentation.Presenters.Menu.File;

namespace Notepad.Presentation.Views.Menu.File {
    public interface ISaveAsView {
        void AttachTo(ISaveAsPresenter presenterToDelegateWorkToo);
    }

    public class SaveAsView : ISaveAsView {
        public void AttachTo(ISaveAsPresenter presenterToDelegateWorkToo) {
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                presenterToDelegateWorkToo.SaveToFileAt(saveFileDialog.FileName);
            }
        }
    }
}