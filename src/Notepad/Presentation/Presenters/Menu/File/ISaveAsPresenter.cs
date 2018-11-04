using Notepad.Infrastructure.Extensions;
using Notepad.Presentation.Core;
using Notepad.Presentation.Views.Menu.File;
using Notepad.Tasks;

namespace Notepad.Presentation.Presenters.Menu.File {
    public interface ISaveAsPresenter : IPresenter {
        void SaveToFileAt(string pathToSaveDocumentTo);
    }

    public class SaveAsPresenter : ISaveAsPresenter {
        private readonly ISaveAsView view;
        private readonly IDocumentTasks tasks;

        public SaveAsPresenter(ISaveAsView view, IDocumentTasks tasks) {
            this.view = view;
            this.tasks = tasks;
        }

        public void Initialize() {
            view.AttachTo(this);
        }

        public void SaveToFileAt(string pathToSaveDocumentTo) {
            tasks.SaveActiveDocumentTo(pathToSaveDocumentTo.AsAnAbsoluteFilePath());
        }
    }
}