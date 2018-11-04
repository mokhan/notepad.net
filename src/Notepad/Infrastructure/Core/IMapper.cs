namespace Notepad.Infrastructure.Core {
    public interface IMapper<Input, Output> {
        Output MapFrom(Input item);
    }
}