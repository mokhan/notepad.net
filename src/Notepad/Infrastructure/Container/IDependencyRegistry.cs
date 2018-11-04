using System.Collections.Generic;

namespace Notepad.Infrastructure.Container {
    public interface IDependencyRegistry {
        Interface FindAnImplementationOf<Interface>();
        IEnumerable<Interface> AllImplementationsOf<Interface>();
    }
}