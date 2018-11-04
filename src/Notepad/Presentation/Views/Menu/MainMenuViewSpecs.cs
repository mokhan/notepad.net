using System.Windows.Forms;
using MbUnit.Framework;
using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu.Mappers;
using Notepad.Presentation.Views.Shell;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Views.Menu {
    public class MainMenuViewSpecs {}

    [TestFixture]
    public class when_adding_sub_menus_to_the_main_menu_ {
        private MockRepository mockery;
        private ISubMenuToToolStripMenuItemMapper mapper;
        private MenuStrip mainMenuStrip;
        private WindowShell mainShell;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            mapper = mockery.DynamicMock<ISubMenuToToolStripMenuItemMapper>();
            mainShell = mockery.DynamicMock<WindowShell>();
            mainMenuStrip = new MenuStrip();

            SetupResult.For(mainShell.MenuStrip()).Return(mainMenuStrip);
        }

        [Test]
        public void should_leverage_the_mapper_to_map_the_sub_menu_to_a_tool_strip_menu_item() {
            var subMenu = mockery.DynamicMock<ISubMenu>();
            var subMenuToolStripMenuItem = new ToolStripMenuItem();

            using (mockery.Record()) {
                Expect
                    .Call(mapper.MapFrom(subMenu))
                    .Return(subMenuToolStripMenuItem)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().Add(subMenu);
            }
        }

        [Test]
        public void should_add_the_mapped_menu_strip_item_to_the_main_menu_strip() {
            var subMenu = mockery.DynamicMock<ISubMenu>();
            var subMenuToolStripMenuItem = new ToolStripMenuItem();

            using (mockery.Record()) {
                SetupResult
                    .For(mapper.MapFrom(subMenu))
                    .Return(subMenuToolStripMenuItem);
            }

            using (mockery.Playback()) {
                CreateSUT().Add(subMenu);
                mainMenuStrip.Items.Contains(subMenuToolStripMenuItem)
                    .ShouldBeEqualTo(true);
            }
        }

        private IMainMenuView CreateSUT() {
            return new MainMenuView(mainShell, mapper);
        }
    }
}