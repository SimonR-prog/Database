namespace Response_Handler.Interfaces
{
    public interface IResult
    {
        bool Success { get; }
        int StatusCode { get; }
        string? ErrorMessage { get; }
    }
}