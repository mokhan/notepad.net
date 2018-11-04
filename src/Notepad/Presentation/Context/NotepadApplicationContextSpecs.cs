using MbUnit.Framework;
using Notepad.Presentation.Context;
using Notepad.Presentation.Core;
using Notepad.Presentation.Model.Menu.File.Commands;
using Notepad.Presentation.Presenters.Shell;
using Notepad.Presentation.Views.Shell;
using Notepad.Test.Extensions;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;
using Rhino.Mocks.Interfaces;

namespace Notepad.Presentation.Context {
    public class NotepadApplicationContextSpecs {}

    [TestFixture]
    public class when_creating_the_application_context_ {
        private MockRepository mockery;
        private WindowShell shellView;
        private IExitCommand exitCommand;
        private IApplicationController applicationController;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            shellView = mockery.DynamicMock<WindowShell>();
            exitCommand = mockery.DynamicMock<IExitCommand>();
            applicationController = mockery.DynamicMock<IApplicationController>();
        }

        [Test]
        public void should_register_for_the_main_shell_views_closing_event() {
            using (mockery.Record()) {
                shellView.Closed += null;
                LastCall.Constraints(Is.NotNull());
            }
            using (mockery.Playback()) {
                CreateSUT();
            }
        }

        [Test]
        public void should_execute_the_exit_application_command() {
            IEventRaiser raiser;
            using (mockery.Record()) {
                shellView.Closed += null;
                raiser = LastCall.Constraints(Is.NotNull()).GetEventRaiser();

                exitCommand.Execute();
            }
            using (mockery.Playback()) {
                CreateSUT();
                raiser.Raise(null, null);
            }
        }

        [Test]
        public void should_specify_the_main_shell_view_as_the_main_form() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().MainForm.ShouldBeEqualTo(shellView);
            }
        }

        [Test]
        public void should_run_the_main_shell_presenter() {
            using (mockery.Record()) {
                applicationController.Run<IMainShellPresenter>();
            }

            using (mockery.Playback()) {
                CreateSUT();
            }
        }

        private NotepadApplicationContext CreateSUT() {
            return new NotepadApplicationContext(shellView, exitCommand, applicationController);
        }
    }
}