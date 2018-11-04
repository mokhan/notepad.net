using MbUnit.Framework;
using Rhino.Mocks;

namespace Notepad.Presentation.Core {
    public class ApplicationControllerSpecs {}

    [TestFixture]
    public class when_the_application_controller_is_asked_to_run_a_presenter_ {
        private MockRepository mockery;
        private IPresenterRegistry presenterRegistry;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            presenterRegistry = mockery.DynamicMock<IPresenterRegistry>();
        }

        [Test]
        public void should_ask_the_registered_presenters_for_an_instance_of_the_presenter_to_run() {
            var implementationOfThePresenter = mockery.DynamicMock<IPresenter>();
            using (mockery.Record()) {
                Expect
                    .Call(presenterRegistry.FindAnImplementationOf<IPresenter>())
                    .Return(implementationOfThePresenter)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().Run<IPresenter>();
            }
        }

        [Test]
        public void should_initialize_the_presenter_to_run() {
            var presenterToInitialize = mockery.DynamicMock<IPresenter>();
            using (mockery.Record()) {
                SetupResult
                    .For(presenterRegistry.FindAnImplementationOf<IPresenter>())
                    .Return(presenterToInitialize);

                presenterToInitialize.Initialize();
            }

            using (mockery.Playback()) {
                CreateSUT().Run<IPresenter>();
            }
        }

        private IApplicationController CreateSUT() {
            return new ApplicationController(presenterRegistry);
        }
    }
}