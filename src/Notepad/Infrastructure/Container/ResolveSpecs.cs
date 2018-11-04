using System;
using MbUnit.Framework;
using Notepad.Presentation.Core;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Infrastructure.Container {
    public class ResolveSpecs {}

    [TestFixture]
    public class when_resolving_a_dependency_using_the_resolve_gateway_ {
        private MockRepository mockery;
        private IDependencyRegistry registry;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            registry = mockery.DynamicMock<IDependencyRegistry>();
            Resolve.InitializeWith(registry);
        }

        [Test]
        public void should_leverage_the_underlying_container_it_was_initialized_with() {
            var presenter = mockery.DynamicMock<IPresenter>();

            using (mockery.Record()) {
                Expect
                    .Call(registry.FindAnImplementationOf<IPresenter>())
                    .Return(presenter)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                Resolve.DependencyFor<IPresenter>();
            }
        }

        [Test]
        public void should_return_the_resolved_dependency() {
            var presenter = mockery.DynamicMock<IPresenter>();

            using (mockery.Record()) {
                Expect
                    .Call(registry.FindAnImplementationOf<IPresenter>())
                    .Return(presenter)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                Resolve.DependencyFor<IPresenter>().ShouldBeEqualTo(presenter);
            }
        }
    }

    [TestFixture]
    public class when_resolving_a_dependency_that_is_not_registered_ {
        private MockRepository mockery;
        private IDependencyRegistry registry;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            registry = mockery.DynamicMock<IDependencyRegistry>();
            Resolve.InitializeWith(registry);
        }

        [Test]
        [ExpectedException(typeof (DependencyResolutionException<IPresenter>))]
        public void should_throw_a_dependency_resolution_exception() {
            using (mockery.Record()) {
                SetupResult
                    .For(registry.FindAnImplementationOf<IPresenter>())
                    .Throw(new Exception());
            }

            using (mockery.Playback()) {
                Resolve.DependencyFor<IPresenter>();
            }
        }
    }
}