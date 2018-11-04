namespace Notepad.Domain.FileSystem {
    public class AbsoluteFilePath : IFilePath {
        private readonly string rawFilePath;

        public AbsoluteFilePath(string rawFilePath) {
            this.rawFilePath = rawFilePath;
        }

        public string RawPathToFile() {
            return rawFilePath;
        }

        public bool Equals(IFilePath other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            return ReferenceEquals(this, other) || Equals(other.RawPathToFile(), rawFilePath);
        }

        public override bool Equals(object other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }
            return other.GetType() == typeof (AbsoluteFilePath) && Equals((AbsoluteFilePath) other);
        }

        public override int GetHashCode() {
            return (rawFilePath != null ? rawFilePath.GetHashCode() : 0);
        }
    }
}