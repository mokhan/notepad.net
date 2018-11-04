using System.Collections.Generic;
using MbUnit.Framework;
using Notepad.Domain.Repositories;
using Notepad.Infrastructure.Extensions;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File {
    public class FileMenuSpecs {}

    [TestFixture]
    public class when_asking_the_file_menu_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo(MenuNames.File);
        }

        private ISubMenu CreateSUT() {
            return new FileMenu(null, null);
        }
    }

    [TestFixture]
    public class when_asking_the_file_menu_for_its_menu_items_ {
        private MockRepository mockery;
        private IRepository<IMenuItem> repository;
        private ISubMenu sut;
        private IMenuItemComparer menuItemComparer;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            repository = mockery.DynamicMock<IRepository<IMenuItem>>();
            menuItemComparer = mockery.DynamicMock<IMenuItemComparer>();

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
        public void should_return_the_menu_items_that_belong_to_the_file_menu() {
            var saveMenuItem = mockery.DynamicMock<IMenuItem>();
            var helpMenuItem = mockery.DynamicMock<IMenuItem>();

            var allMenuItems = new List<IMenuItem> {saveMenuItem, helpMenuItem};

            using (mockery.Record()) {
                SetupResult.For(repository.All()).Return(allMenuItems);
                SetupResult.For(saveMenuItem.BelongsTo(sut)).Return(true);
                SetupResult.For(helpMenuItem.BelongsTo(sut)).Return(false);
            }

            using (mockery.Playback()) {
                var returnedItems = sut.AllMenuItems();
                returnedItems.ShouldContain(saveMenuItem);
                returnedItems.ShouldNotContain(helpMenuItem);
            }
        }

        [Test]
        public void should_sort_the_items_in_the_file_menu() {
            var firstItem = mockery.DynamicMock<IMenuItem>();
            var secondItem = mockery.DynamicMock<IMenuItem>();

            var allMenuItems = new List<IMenuItem> {firstItem, secondItem};

            using (mockery.Record()) {
                SetupResult.For(repository.All()).Return(allMenuItems);
                SetupResult.For(firstItem.BelongsTo(null))
                    .IgnoreArguments()
                    .Return(true);
                SetupResult.For(secondItem.BelongsTo(null))
                    .IgnoreArguments()
                    .Return(true);
                Expect
                    .Call(menuItemComparer.Compare(firstItem, secondItem))
                    .Return(1)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                sut.AllMenuItems().Walk();
            }
        }

        private ISubMenu CreateSUT() {
            return new FileMenu(repository, menuItemComparer);
        }
    }
}