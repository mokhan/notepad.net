namespace Notepad.Infrastructure.Extensions {
    public static class ConversionExtensions {
        public static T DowncastTo<T>(this object objectToCast) {
            return (T) objectToCast;
        }
    }
}