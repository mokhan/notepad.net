using MbUnit.Framework;
using Notepad.Presentation.Core;
using Notepad.Presentation.Presenters.Menu.File;
using Notepad.Tasks;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File.Commands {
    public class SaveCommandSpecs {}

    [TestFixture]
    public class when_executing_the_save_command_and_a_file_path_to_save_to_has_not_been_specified_ {
        private MockRepository mockery;
        private IApplicationController applicationController;
        private IDocumentTasks tasks;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            applicationController = mockery.DynamicMock<IApplicationController>();
            tasks = mockery.DynamicMock<IDocumentTasks>();

            SetupResult.For(tasks.HasAPathToSaveToBeenSpecified()).Return(false);
        }

        [Test]
        public void should_run_the_save_as_presenter() {
            using (mockery.Record()) {
                applicationController.Run<ISaveAsPresenter>();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        [Test]
        public void should_not_save_the_active_document() {
            using (mockery.Record()) {
                tasks.SaveTheActiveDocument();
                LastCall.Repeat.Never();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        private ISaveCommand CreateSUT() {
            return new SaveCommand(applicationController, tasks);
        }
    }

    [TestFixture]
    public class when_executing_the_save_command_and_a_path_to_save_to_has_already_been_specified_ {
        private MockRepository mockery;
        private IApplicationController applicationController;
        private IDocumentTasks tasks;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            applicationController = mockery.DynamicMock<IApplicationController>();
            tasks = mockery.DynamicMock<IDocumentTasks>();

            SetupResult.For(tasks.HasAPathToSaveToBeenSpecified()).Return(true);
        }

        [Test]
        public void should_not_run_the_save_as_presenter() {
            using (mockery.Record()) {
                applicationController.Run<ISaveAsPresenter>();
                LastCall.Repeat.Never();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        [Test]
        public void should_save_the_active_document() {
            using (mockery.Record()) {
                tasks.SaveTheActiveDocument();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        private ISaveCommand CreateSUT() {
            return new SaveCommand(applicationController, tasks);
        }
    }
}