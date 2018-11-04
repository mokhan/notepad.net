using System;
using System.Linq.Expressions;

namespace Notepad.Test {
    public class Call {
        public static IActionRecorder To(Expression<Action> actionToRecord) {
            return new ActionRecorder(actionToRecord.Compile());
        }
    }

    public class ActionRecorder : IActionRecorder {
        private readonly Action actionToRecord;

        public ActionRecorder(Action actionToRecord) {
            this.actionToRecord = actionToRecord;
        }

        public Action ActionToRecord() {
            return actionToRecord;
        }
    }

    public interface IActionRecorder {
        Action ActionToRecord();
    }

    public static class ActionRecorderExtensions {
        public static void ShouldThrow<ThisException>(this IActionRecorder recorder) where ThisException : Exception {
            try {
                recorder.ActionToRecord()();
            }
            catch (ThisException) {
                return;
            }
        }
    }
}