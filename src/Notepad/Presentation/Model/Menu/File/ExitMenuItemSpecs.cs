using MbUnit.Framework;
using Notepad.Presentation.Model.Menu.File.Commands;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File {
    public class ExitMenuItemSpecs {}

    [TestFixture]
    public class when_asking_the_exit_menu_item_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo("E&xit");
        }

        private IMenuItem CreateSUT() {
            return new ExitMenuItem(null);
        }
    }

    [TestFixture]
    public class when_clicking_on_the_exit_menu_item_ {
        private MockRepository mockery;
        private IExitCommand exitCommand;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            exitCommand = mockery.DynamicMock<IExitCommand>();
        }

        [Test]
        public void should_execute_the_exit_command() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().Click();
            }
        }

        private IMenuItem CreateSUT() {
            return new ExitMenuItem(exitCommand);
        }
    }

    [TestFixture]
    public class when_asking_the_exit_menu_item_if_it_belongs_to_a_menu_that_it_does {
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
            return new ExitMenuItem(null);
        }
    }
}