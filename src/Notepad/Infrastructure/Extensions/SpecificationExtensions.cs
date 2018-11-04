using System;
using Notepad.Infrastructure.Core;

namespace Notepad.Infrastructure.Extensions {
    public static class SpecificationExtensions {
        public static bool Satisfies<T>(this T itemToValidate, Predicate<T> criteriaToSatisfy) {
            return criteriaToSatisfy(itemToValidate);
        }

        public static bool Satisfies<T>(this T itemToValidate, ISpecification<T> criteriaToSatisfy) {
            return itemToValidate.Satisfies(criteriaToSatisfy.IsSatisfiedBy);
        }
    }
}