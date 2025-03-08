using Response_Handler.Interfaces;

namespace Response_Handler.Models;

public abstract class Result : IResult
{
    public bool Success { get; protected set; }
    public int StatusCode { get; protected set; }
    public string? ErrorMessage { get; protected set; }

    public static Result Ok()
    {
        return new SuccessResult(200);
    }
    public static Result BadRequest(string message)
    {
        return new ErrorResult(400, message);
    }
    public static Result NotFound(string message)
    {
        return new ErrorResult(404, message);
    }
    public static Result AlreadyExists(string message)
    {
        return new ErrorResult(409, message);
    }
    public static Result Error(string message)
    {
        return new ErrorResult(500, message);
    }

}
public class Result<T> : Result, IResultContent<T>
{
    public T? Content { get; private set; }
    public static Result<T> Ok(T? content)
    {
        return new Result<T>
        {
            Success = true,
            StatusCode = 200,
            Content = content
        };
    }

    // Gotten from chatgpt to be able to return an empty list when getting entities from the database.
    public static Result<T> Error(T? content, string message)
    {
        return new Result<T>
        {
            Success = false,
            StatusCode = 500,
            Content = content,
            ErrorMessage = message
        };
    }
}
