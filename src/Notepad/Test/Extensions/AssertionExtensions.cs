using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;

namespace Notepad.Test.Extensions {
    public static class AssertionExtensions {
        public static void ShouldBeEqualTo<T>(this T itemToValidate, T expectedValue) {
            Assert.AreEqual(expectedValue, itemToValidate);
        }

        public static void ShouldBeSameInstanceAs<T>(this T left, T right) {
            Assert.IsTrue(ReferenceEquals(left, right));
        }

        public static void ShouldNotBeNull<T>(this T itemToCheck) where T : class {
            Assert.IsNotNull(itemToCheck);
        }

        public static void ShouldBeGreaterThan(this int actual, int expected) {
            Assert.GreaterThan(actual, expected);
        }

        public static void ShouldBeLessThan(this int actual, int expected) {
            Assert.Less(actual, expected);
        }

        public static void ShouldContain<T>(this IEnumerable<T> itemsToPeekInto, T itemToLookFor) {
            Assert.IsTrue(itemsToPeekInto.Contains(itemToLookFor));
        }

        public static void ShouldNotContain<T>(this IEnumerable<T> itemsToPeekInto, T itemToLookFor) {
            Assert.IsFalse(itemsToPeekInto.Contains(itemToLookFor));
        }
    }
}