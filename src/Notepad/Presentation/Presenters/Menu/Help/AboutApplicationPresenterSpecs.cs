using MbUnit.Framework;
using Notepad.Presentation.Views.Menu.Help;
using Rhino.Mocks;

namespace Notepad.Presentation.Presenters.Menu.Help {
    public class AboutApplicationPresenterSpecs {}

    [TestFixture]
    public class when_initializing_the_application_information_presenter_ {
        private MockRepository mockery;
        private IAboutApplicationView view;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            view = mockery.DynamicMock<IAboutApplicationView>();
        }

        [Test]
        public void should_display_the_view() {
            using (mockery.Record()) {
                view.Display();
            }

            using (mockery.Playback()) {
                CreateSUT().Initialize();
            }
        }

        private IAboutApplicationPresenter CreateSUT() {
            return new AboutApplicationPresenter(view);
        }
    }
}