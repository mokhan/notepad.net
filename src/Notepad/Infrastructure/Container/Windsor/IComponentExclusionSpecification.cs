using System;
using System.Windows.Forms;
using Notepad.Infrastructure.Core;

namespace Notepad.Infrastructure.Container.Windsor {
    public interface IComponentExclusionSpecification : ISpecification<Type> {}

    public class ComponentExclusionSpecification : IComponentExclusionSpecification {
        public bool IsSatisfiedBy(Type type) {
            return type.GetInterfaces().Length == 0
                   || type.IsSubclassOf(typeof (Form))
                   || type.IsAssignableFrom(typeof (IDependencyRegistry));
        }
    }
}