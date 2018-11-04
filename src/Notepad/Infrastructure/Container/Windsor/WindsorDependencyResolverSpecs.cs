using Castle.Windsor;
using MbUnit.Framework;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Infrastructure.Container.Windsor {
    public class WindsorDependencyResolverSpecs {}


    [TestFixture]
    public class when_registering_a_singleton_component_with_the_windsor_container_ {
        private WindsorDependencyRegistry sut;

        [SetUp]
        public void SetUp() {
            sut = CreateSUT();
        }

        [Test]
        public void should_return_the_same_instance_each_time_its_resolved() {
            sut
                .FindAnImplementationOf<IBird>()
                .ShouldBeSameInstanceAs(sut.FindAnImplementationOf<IBird>());
        }

        [Test]
        public void should_not_return_null() {
            sut.FindAnImplementationOf<IBird>().ShouldNotBeNull();
        }

        private WindsorDependencyRegistry CreateSUT() {
            return new WindsorDependencyRegistry();
        }
    }

    [TestFixture]
    public class when_creating_the_windsor_resolver_ {
        private MockRepository mockery;
        private IWindsorContainerFactory factory;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            factory = mockery.DynamicMock<IWindsorContainerFactory>();
        }

        [Test]
        public void should_leverage_the_factory_to_create_the_underlying_container() {
            var container = new WindsorContainer();
            using (mockery.Record()) {
                Expect
                    .Call(factory.Create())
                    .Return(container)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT();
            }
        }

        private IDependencyRegistry CreateSUT() {
            return new WindsorDependencyRegistry(factory);
        }
    }

    public class BlueBird : IBird {
        public void Initialize() {}
    }

    public interface IBird {}
}