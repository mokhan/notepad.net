using System.Collections.Generic;
using System.Windows.Forms;
using MbUnit.Framework;
using Notepad.Infrastructure.Core;
using Notepad.Presentation.Model.Menu;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Views.Menu.Mappers {
    public class SubMenuToToolStripMenuItemMapperSpecs {}

    [TestFixture]
    public class when_mapping_a_sub_menu_to_a_tool_strip_menu_item_ {
        private MockRepository mockery;
        private ISubMenu subMenu;
        private IList<IMenuItem> menuItems;
        private IMenuItemToToolStripMenuItemMapper mapper;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            subMenu = mockery.DynamicMock<ISubMenu>();
            mapper = mockery.DynamicMock<IMenuItemToToolStripMenuItemMapper>();
            menuItems = new List<IMenuItem>();

            SetupResult.For(subMenu.Name()).Return("&File");
            SetupResult.For(subMenu.AllMenuItems()).Return(menuItems);
        }

        [Test]
        public void should_return_a_non_null_value() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().MapFrom(subMenu).ShouldNotBeNull();
            }
        }

        [Test]
        public void should_return_a_menu_item_with_the_sub_menus_name_applied_as_its_text() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().MapFrom(subMenu).Text.ShouldBeEqualTo("&File");
            }
        }

        [Test]
        public void should_map_each_of_the_sub_menus_menu_items_to_tool_strip_menu_items() {
            var firstMenuItem = mockery.DynamicMock<IMenuItem>();

            menuItems.Add(firstMenuItem);
            using (mockery.Record()) {
                Expect
                    .Call(mapper.MapFrom(firstMenuItem))
                    .Return(new ToolStripMenuItem())
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().MapFrom(subMenu);
            }
        }

        [Test]
        public void should_add_all_the_mapped_menu_items_to_the_menu_item_representing_the_sub_menu() {
            var firstMenuItem = mockery.DynamicMock<IMenuItem>();
            var mappedMenuItem = new ToolStripMenuItem();

            menuItems.Add(firstMenuItem);
            using (mockery.Record()) {
                SetupResult
                    .For(mapper.MapFrom(firstMenuItem))
                    .Return(mappedMenuItem)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().MapFrom(subMenu).DropDownItems.Contains(mappedMenuItem)
                    .ShouldBeEqualTo(true);
            }
        }

        private IMapper<ISubMenu, ToolStripMenuItem> CreateSUT() {
            return new SubMenuToToolStripMenuItemMapper(mapper);
        }
    }
}