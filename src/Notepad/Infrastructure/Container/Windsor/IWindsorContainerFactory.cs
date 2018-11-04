using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Notepad.Infrastructure.Extensions;

namespace Notepad.Infrastructure.Container.Windsor {
    public interface IWindsorContainerFactory {
        IWindsorContainer Create();
    }

    public class WindsorContainerFactory : IWindsorContainerFactory {
        private static IWindsorContainer container;
        private IComponentExclusionSpecification criteriaToSatisfy;

        public WindsorContainerFactory() : this(new ComponentExclusionSpecification()) {}

        public WindsorContainerFactory(IComponentExclusionSpecification criteriaToSatisfy) {
            this.criteriaToSatisfy = criteriaToSatisfy;
        }

        public IWindsorContainer Create() {
            if (null == container) {
                container = new WindsorContainer();
                container.Register(
                    AllTypes
                        .Pick()
                        .FromAssembly(GetType().Assembly)
                        .WithService
                        .FirstInterface()
                        .Unless(criteriaToSatisfy.IsSatisfiedBy)
                        .Configure(
                        delegate(ComponentRegistration registration) {
                            this.LogInformational("{1}-{0}", registration.Implementation, registration.ServiceType.Name);
                            if (registration.Implementation.GetInterfaces().Length == 0) {
                                registration.For(registration.Implementation);
                            }
                        })
                    );
            }
            return container;
        }
    }
}