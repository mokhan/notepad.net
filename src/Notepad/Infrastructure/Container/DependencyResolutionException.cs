using System;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Infrastructure.Container {
    public class DependencyResolutionException<T> : Exception {
        public DependencyResolutionException(Exception innerException)
            : base("Could not resolve {0}".FormatWith(typeof (T).FullName), innerException) {}
    }
}