using System;

namespace Notepad.Infrastructure.Container {
    public static class Resolve {
        private static IDependencyRegistry underlyingRegistry;

        public static void InitializeWith(IDependencyRegistry registry) {
            underlyingRegistry = registry;
        }

        public static DependencyToResolve DependencyFor<DependencyToResolve>() {
            try {
                return underlyingRegistry.FindAnImplementationOf<DependencyToResolve>();
            }
            catch (Exception e) {
                throw new DependencyResolutionException<DependencyToResolve>(e);
            }
        }
    }
}