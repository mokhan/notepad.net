using System.Collections.Generic;
using MbUnit.Framework;
using Notepad.Domain.Repositories;
using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu;
using Rhino.Mocks;

namespace Notepad.Presentation.Presenters.Menu {
    public class MainMenuPresenterSpecs {}

    [TestFixture]
    public class when_initializing_the_main_menu_presenter_ {
        private MockRepository mockery;
        private IRepository<ISubMenu> repository;
        private IMainMenuView mainMenu;
        private ISubMenuItemComparer comparer;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            repository = mockery.DynamicMock<IRepository<ISubMenu>>();
            mainMenu = mockery.DynamicMock<IMainMenuView>();
            comparer = mockery.DynamicMock<ISubMenuItemComparer>();
        }

        [Test]
        public void should_ask_the_repository_for_all_the_sub_menus() {
            var subMenus = new List<ISubMenu>();
            using (mockery.Record()) {
                Expect
                    .Call(repository.All())
                    .Return(subMenus)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().Initialize();
            }
        }

        [Test]
        public void should_add_each_of_the_sub_menus_to_the_main_menu() {
            var fileMenu = mockery.DynamicMock<ISubMenu>();
            var subMenus = new List<ISubMenu> {fileMenu};

            using (mockery.Record()) {
                SetupResult
                    .For(repository.All())
                    .Return(subMenus);
                mainMenu.Add(fileMenu);
            }

            using (mockery.Playback()) {
                CreateSUT().Initialize();
            }
        }

        [Test]
        public void should_sort_the_sub_menus_using_the_comparer() {
            var firstMenu = mockery.DynamicMock<ISubMenu>();
            var secondMenu = mockery.DynamicMock<ISubMenu>();

            var subMenus = new List<ISubMenu> {firstMenu, secondMenu};

            using (mockery.Record()) {
                SetupResult
                    .For(repository.All())
                    .Return(subMenus);
                Expect
                    .Call(comparer.Compare(firstMenu, secondMenu))
                    .Return(0)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().Initialize();
            }
        }

        private IMainMenuPresenter CreateSUT() {
            return new MainMenuPresenter(mainMenu, repository, comparer);
        }
    }
}