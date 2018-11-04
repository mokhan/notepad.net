using System;
using System.Collections.Generic;

namespace Notepad.Infrastructure.Extensions {
    public static class EnumerableExtensions {
        public static void Walk<T>(this IEnumerable<T> itemsToWalk) {
            foreach (var item in itemsToWalk) {}
        }

        public static IEnumerable<T> ThatSatisfy<T>(this IEnumerable<T> itemsToPeekInto, Predicate<T> criteriaToSatisfy) {
            foreach (var item in itemsToPeekInto) {
                if (item.Satisfies(criteriaToSatisfy)) {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> SortedUsing<T>(this IEnumerable<T> itemsToSort, IComparer<T> sortingAlgorithm) {
            var sortedItems = new List<T>(itemsToSort);
            sortedItems.Sort(sortingAlgorithm);
            return sortedItems;
        }
    }
}