using System;
using System.Collections.Generic;
using Castle.Windsor;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Infrastructure.Container.Windsor {
    public class WindsorDependencyRegistry : IDependencyRegistry {
        private IWindsorContainer underlyingContainer;

        public WindsorDependencyRegistry() : this(new WindsorContainerFactory()) {}

        public WindsorDependencyRegistry(IWindsorContainerFactory factory) {
            underlyingContainer = factory.Create();
        }

        public Interface FindAnImplementationOf<Interface>() {
            return underlyingContainer.Kernel.Resolve<Interface>();
        }

        public void Register(Type typeOfInterface, Type typeOfImplementation) {
            underlyingContainer
                .Kernel
                .AddComponent("{0}-{1}".FormatWith(typeOfInterface.FullName, typeOfImplementation.FullName),
                              typeOfInterface,
                              typeOfImplementation);
        }

        public void Register<Interface, Implementation>() {
            Register(typeof (Interface), typeof (Implementation));
        }

        public void RegisterInstanceOf<Interface>(Interface instanceOfTheInterface) {
            underlyingContainer.Kernel.AddComponentInstance<Interface>(instanceOfTheInterface);
        }

        public IEnumerable<Interface> AllImplementationsOf<Interface>() {
            return underlyingContainer.Kernel.ResolveAll<Interface>();
        }
    }
}