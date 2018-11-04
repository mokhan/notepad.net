namespace Notepad.Infrastructure.Core {
    public interface ISpecification<T> {
        bool IsSatisfiedBy(T item);
    }
}