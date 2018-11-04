using Notepad.Domain.FileSystem;

namespace Notepad.Infrastructure.Extensions {
    public static class StringExtensions {
        public static string FormatWith(this string formattedString, params object[] arguments) {
            return string.Format(formattedString, arguments);
        }

        public static IFilePath AsAnAbsoluteFilePath(this string rawFilePath) {
            return new AbsoluteFilePath(rawFilePath);
        }
    }
}