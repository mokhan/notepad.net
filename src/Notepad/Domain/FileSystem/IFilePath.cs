using System;

namespace Notepad.Domain.FileSystem {
    public interface IFilePath : IEquatable<IFilePath> {
        string RawPathToFile();
    }
}