using MbUnit.Framework;
using Notepad.Presentation.Presenters.Commands;
using Notepad.Presentation.Presenters.Menu.Help;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.Help {
    public class AboutMenuItemSpecs {}

    [TestFixture]
    public class when_asking_the_about_menu_item_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo(MenuItemNames.About);
        }

        private IMenuItem CreateSUT() {
            return new AboutMenuItem(null);
        }
    }

    [TestFixture]
    public class when_clicking_on_the_about_menu_item_ {
        private MockRepository mockery;
        private IRunPresenterCommand<IAboutApplicationPresenter> displayAboutCommand;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            displayAboutCommand = mockery.DynamicMock<IRunPresenterCommand<IAboutApplicationPresenter>>();
        }

        [Test]
        public void should_execute_the_display_about_command() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().Click();
            }
        }

        private IMenuItem CreateSUT() {
            return new AboutMenuItem(displayAboutCommand);
        }
    }

    [TestFixture]
    public class when_asking_the_about_menu_item_if_it_belongs_to_a_menu_that_it_does {
        private MockRepository mockery;
        private ISubMenu menuThatThisItemBelongsTo;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            menuThatThisItemBelongsTo = mockery.DynamicMock<ISubMenu>();

            SetupResult.For(menuThatThisItemBelongsTo.Name()).Return(MenuNames.Help);
        }

        [Test]
        public void should_return_true() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().BelongsTo(menuThatThisItemBelongsTo).ShouldBeEqualTo(true);
            }
        }

        private IMenuItem CreateSUT() {
            return new AboutMenuItem(null);
        }
    }

    [TestFixture]
    public class when_asking_the_about_menu_item_if_it_belongs_to_a_menu_item_that_it_does_not {
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
            return new AboutMenuItem(null);
        }
    }
}