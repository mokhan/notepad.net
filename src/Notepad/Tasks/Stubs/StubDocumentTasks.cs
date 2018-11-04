using Notepad.Domain.FileSystem;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Tasks.Stubs {
    public class StubDocumentTasks : IDocumentTasks {
        public void SaveActiveDocumentTo(IFilePath pathToSaveTheActiveDocumentTo) {
            pathToSaveTheActiveDocumentTo
                .LogInformational("Save document to {0}", pathToSaveTheActiveDocumentTo.RawPathToFile());
        }

        public bool HasAPathToSaveToBeenSpecified() {
            return false;
        }

        public void SaveTheActiveDocument() {
            this.LogInformational("Save the active document please...");
        }
    }
}