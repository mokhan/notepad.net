using MbUnit.Framework;
using Notepad.Test.Extensions;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File {
    public class NewMenuItemSpecs {}

    [TestFixture]
    public class when_asking_the_new_file_menu_if_it_belongs_to_the_file_menu_ {
        private MockRepository mockery;
        private ISubMenu fileMenu;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            fileMenu = mockery.DynamicMock<ISubMenu>();

            SetupResult.For(fileMenu.Name()).Return("&File");
        }

        [Test]
        public void should_return_true() {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().BelongsTo(fileMenu).ShouldBeEqualTo(true);
            }
        }

        private IMenuItem CreateSUT() {
            return new NewMenuItem();
        }
    }

    [TestFixture]
    public class when_asking_the_new_file_menu_item_for_its_name_ {
        [Test]
        public void should_return_the_correct_name() {
            CreateSUT().Name().ShouldBeEqualTo("&New");
        }

        private IMenuItem CreateSUT() {
            return new NewMenuItem();
        }
    }
}