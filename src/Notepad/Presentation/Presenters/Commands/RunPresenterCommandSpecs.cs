using MbUnit.Framework;
using Notepad.Presentation.Core;
using Rhino.Mocks;

namespace Notepad.Presentation.Presenters.Commands {
    public class RunPresenterCommandSpecs {}

    [TestFixture]
    public class when_executing_the_run_presenter_command_ {
        private MockRepository mockery;
        private IApplicationController applicationController;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            applicationController = mockery.DynamicMock<IApplicationController>();
        }

        [Test]
        public void should_run_the_display_about_presenter() {
            using (mockery.Record()) {
                applicationController.Run<IPresenter>();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        private IRunPresenterCommand<IPresenter> CreateSUT() {
            return new RunPresenterCommand<IPresenter>(applicationController);
        }
    }
}