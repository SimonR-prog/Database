namespace Response_Handler.Models;

public class ErrorResult : Result
{
    public ErrorResult(int statusCode,  string message)
    {
        Success = false;
        StatusCode = statusCode;
        ErrorMessage = message;
    }
}
