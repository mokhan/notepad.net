using MbUnit.Framework;
using Notepad.Presentation.Model.Menu;
using Notepad.Presentation.Views.Menu.Mappers;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Views.Menu.Mappers {
    public class MenuItemToToolStripMenuItemMapperSpecs {}

    [TestFixture]
    public class when_mapping_a_menu_item_to_a_tool_strip_menu_item_ {
        private MockRepository mockery;
        private IMenuItem menuItem;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            menuItem = mockery.DynamicMock<IMenuItem>();

            SetupResult.For(menuItem.Name()).Return("&Save");
        }

        [Test]
        public void should_return_a_tool_strip_menu_item_with_the_menu_items_name_applied_as_its_text() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().MapFrom(menuItem).Text.ShouldBeEqualTo("&Save");
            }
        }

        [Test]
        public void should_invoke_the_menu_items_click_method_when_the_tool_strip_menu_item_is_clicked() {
            using (mockery.Record()) {
                menuItem.Click();
            }

            using (mockery.Playback()) {
                CreateSUT().MapFrom(menuItem).PerformClick();
            }
        }

        private IMenuItemToToolStripMenuItemMapper CreateSUT() {
            return new MenuItemToToolStripMenuItemMapper();
        }
    }
}