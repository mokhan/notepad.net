using MbUnit.Framework;
using Notepad.Infrastructure.Container;
using Rhino.Mocks;

namespace Notepad.Infrastructure.Logging {
    public class LogSpecs {}

    [TestFixture]
    public class when_creating_a_logger_for_a_particular_type_ {
        private MockRepository mockery;
        private ILogFactory factory;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            factory = mockery.DynamicMock<ILogFactory>();

            var resolver = mockery.DynamicMock<IDependencyRegistry>();
            SetupResult.For(resolver.FindAnImplementationOf<ILogFactory>()).Return(factory);

            Resolve.InitializeWith(resolver);
        }

        [Test]
        public void should_leverage_the_log_factory_to_create_a_logger_for_the_given_type() {
            var logger = mockery.DynamicMock<ILogger>();
            using (mockery.Record()) {
                Expect
                    .Call(factory.CreateFor(GetType()))
                    .Return(logger)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                Log.For(this);
            }
        }
    }
}