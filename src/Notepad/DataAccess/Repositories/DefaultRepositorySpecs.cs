using System.Collections.Generic;
using MbUnit.Framework;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Container;
using Rhino.Mocks;

namespace Notepad.DataAccess.Repositories {
    public class DefaultRepositorySpecs {}

    [TestFixture]
    public class when_retrieving_all_the_items_from_the_default_repository {
        private MockRepository mockery;
        private IDependencyRegistry registry;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            registry = mockery.DynamicMock<IDependencyRegistry>();
        }

        [Test]
        public void should_leverage_the_resolver_to_retrieve_all_the_implementations() {
            var intsToReturn = new List<int>();

            using (mockery.Record()) {
                Expect
                    .Call(registry.AllImplementationsOf<int>())
                    .Return(intsToReturn)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().All();
            }
        }

        private IRepository<int> CreateSUT() {
            return new DefaultRepository<int>(registry);
        }
    }
}