namespace Response_Handler.Models;

public class SuccessResult : Result
{
    public SuccessResult(int statusCode)
    {
        Success = true;
        StatusCode = statusCode;
    }
}