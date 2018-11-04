using MbUnit.Framework;
using Notepad.Presentation.Model.Menu.File.Commands;
using Notepad.Presentation.Presenters.Commands;
using Notepad.Presentation.Presenters.Menu.File;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File {
    public class SaveAsMenuItemSpecs {}

    [TestFixture]
    public class when_asking_the_save_as_menu_item_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo("Save &As...");
        }

        private IMenuItem CreateSUT() {
            return new SaveAsMenuItem(null);
        }
    }

    [TestFixture]
    public class when_clicking_on_the_save_as_menu_item_ {
        private MockRepository mockery;
        private IRunPresenterCommand<ISaveAsPresenter> saveAsCommand;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            saveAsCommand = mockery.DynamicMock<IRunPresenterCommand<ISaveAsPresenter>>();
        }

        [Test]
        public void should_execute_the_save_as_command() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().Click();
            }
        }

        private IMenuItem CreateSUT() {
            return new SaveAsMenuItem(saveAsCommand);
        }
    }

    [TestFixture]
    public class when_asking_the_save_as_menu_item_if_it_belongs_to_a_menu_that_it_does {
        private MockRepository mockery;
        private ISubMenu fileMenu;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            fileMenu = mockery.DynamicMock<ISubMenu>();

            SetupResult.For(fileMenu.Name()).Return(MenuNames.File);
        }

        [Test]
        public void should_return_true() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().BelongsTo(fileMenu).ShouldBeEqualTo(true);
            }
        }

        private IMenuItem CreateSUT() {
            return new SaveAsMenuItem(null);
        }
    }

    [TestFixture]
    public class when_asking_the_save_as_menu_item_if_it_belongs_to_a_menu_item_that_it_does_not {
        private MockRepository mockery;
        private ISubMenu unknownMenu;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            unknownMenu = mockery.DynamicMock<ISubMenu>();

            SetupResult.For(unknownMenu.Name()).Return("blah");
        }

        [Test]
        public void should_return_false() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().BelongsTo(unknownMenu).ShouldBeEqualTo(false);
            }
        }


        private IMenuItem CreateSUT() {
            return new SaveAsMenuItem(null);
        }
    }
}