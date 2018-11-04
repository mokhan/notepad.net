using System.Collections.Generic;
using MbUnit.Framework;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Extensions;
using Notepad.Presentation.Model.Menu.Help;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.Help {
    public class HelpMenuSpecs {}

    [TestFixture]
    public class when_asking_the_help_menu_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo(MenuNames.Help);
        }

        private ISubMenu CreateSUT() {
            return new HelpMenu(null);
        }
    }

    [TestFixture]
    public class when_asking_the_help_menu_for_its_menu_items_ {
        private MockRepository mockery;
        private IRepository<IMenuItem> repository;
        private ISubMenu sut;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            repository = mockery.DynamicMock<IRepository<IMenuItem>>();
            sut = CreateSUT();
        }

        [Test]
        public void should_ask_the_repository_for_all_the_menu_items() {
            using (mockery.Record()) {
                Expect
                    .Call(repository.All())
                    .Return(new List<IMenuItem>())
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                sut.AllMenuItems().Walk();
            }
        }

        [Test]
        public void should_return_the_menu_items_that_belong_to_the_help_menu() {
            var saveMenuItem = mockery.DynamicMock<IMenuItem>();
            var helpMenuItem = mockery.DynamicMock<IMenuItem>();

            var allMenuItems = new List<IMenuItem> {saveMenuItem, helpMenuItem};

            using (mockery.Record()) {
                SetupResult.For(repository.All()).Return(allMenuItems);
                SetupResult.For(saveMenuItem.BelongsTo(sut)).Return(false);
                SetupResult.For(helpMenuItem.BelongsTo(sut)).Return(true);
            }

            using (mockery.Playback()) {
                var returnedItems = sut.AllMenuItems();
                returnedItems.ShouldNotContain(saveMenuItem);
                returnedItems.ShouldContain(helpMenuItem);
            }
        }

        private ISubMenu CreateSUT() {
            return new HelpMenu(repository);
        }
    }
}