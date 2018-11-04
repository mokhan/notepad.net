using System.Collections.Generic;

namespace Notepad.Domain.Repositories {
    public interface IRepository<T> {
        IEnumerable<T> All();
    }
}