using System.Collections.Generic;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Container;

namespace Notepad.DataAccess.Repositories {
    public class DefaultRepository<T> : IRepository<T> {
        private IDependencyRegistry registry;

        public DefaultRepository(IDependencyRegistry registry) {
            this.registry = registry;
        }

        public IEnumerable<T> All() {
            return registry.AllImplementationsOf<T>();
        }
    }
}