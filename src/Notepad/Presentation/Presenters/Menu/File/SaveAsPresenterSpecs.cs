using MbUnit.Framework;
using Notepad.Infrastructure.Extensions;
using Notepad.Presentation.Model.Menu.File.Commands;
using Notepad.Presentation.Views.Menu.File;
using Notepad.Tasks;
using Rhino.Mocks;

namespace Notepad.Presentation.Presenters.Menu.File {
    public class SaveAsPresenterSpecs {}

    [TestFixture]
    public class when_initializing_the_save_as_presenter_ {
        private MockRepository mockery;
        private ISaveAsView view;
        private ISaveAsPresenter sut;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            view = mockery.DynamicMock<ISaveAsView>();

            sut = CreateSUT();
        }

        private ISaveAsPresenter CreateSUT() {
            return new SaveAsPresenter(view, null);
        }

        [Test]
        public void should_initialize_the_view_with_itself() {
            using (mockery.Record()) {
                view.AttachTo(sut);
            }

            using (mockery.Playback()) {
                sut.Initialize();
            }
        }
    }

    [TestFixture]
    public class when_selecting_a_file_path_to_save_to_ {
        private MockRepository mockery;
        private ISaveCommand saveCommand;
        private IDocumentTasks tasks;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            tasks = mockery.DynamicMock<IDocumentTasks>();
        }

        [Test]
        public void should_ask_the_active_document_to_save_the_path_specified() {
            var pathToSaveFileTo = "some path";
            using (mockery.Record()) {
                tasks.SaveActiveDocumentTo(pathToSaveFileTo.AsAnAbsoluteFilePath());
            }

            using (mockery.Playback()) {
                CreateSUT().SaveToFileAt(pathToSaveFileTo);
            }
        }

        private ISaveAsPresenter CreateSUT() {
            return new SaveAsPresenter(null, tasks);
        }
    }
}