using MbUnit.Framework;
using Notepad.Infrastructure.System;
using Rhino.Mocks;

namespace Notepad.Presentation.Model.Menu.File.Commands {
    public class ExitCommandSpecs {}

    [TestFixture]
    public class when_executing_the_exit_command_specs_ {
        private MockRepository mockery;
        private IApplicationEnvironment application;

        [SetUp]
        public void SetUp() {
            mockery = new MockRepository();
            application = mockery.DynamicMock<IApplicationEnvironment>();
        }

        [Test]
        public void should_ask_the_application_environment_to_shut_down() {
            using (mockery.Record()) {
                application.ShutDown();
            }

            using (mockery.Playback()) {
                CreateSUT().Execute();
            }
        }

        private IExitCommand CreateSUT() {
            return new ExitCommand(application);
        }
    }
}