using Notepad.Domain.FileSystem;

namespace Notepad.Tasks {
    public interface IDocumentTasks {
        void SaveActiveDocumentTo(IFilePath pathToSaveTheActiveDocumentTo);
        bool HasAPathToSaveToBeenSpecified();
        void SaveTheActiveDocument();
    }
}