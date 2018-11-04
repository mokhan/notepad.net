using MbUnit.Framework;
using Notepad.Presentation.Core;
using Notepad.Presentation.Presenters.Menu;
using Notepad.Presentation.Presenters.Shell;
using Rhino.Mocks;

namespace Notepad.Presentation.Presenters.Shell {
    public class MainShellPresenterSpecs {}

    [TestFixture]
    public class when_initializing_the_main_shell_presenter_ {
        private MockRepository mockery;
        private IApplicationController applicationController;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            applicationController = mockery.DynamicMock<IApplicationController>();
        }

        [Test]
        public void should_initialize_the_main_menu_presenter() {
            using (mockery.Record()) {
                applicationController.Run<IMainMenuPresenter>();
            }

            using (mockery.Playback()) {
                CreateSUT().Initialize();
            }
        }

        private IMainShellPresenter CreateSUT() {
            return new MainShellPresenter(applicationController);
        }
    }
}