namespace Response_Handler.Interfaces;

public interface IResultContent<T> : IResult
{
    T? Content { get; }
}
