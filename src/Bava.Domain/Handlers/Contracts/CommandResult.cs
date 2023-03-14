namespace Bava.Domain.Handlers.Contracts;

public enum Status
{
    Ok,
    Created,
    NotFound,
    Invalid,
    Unauthorized,
}

public class CommandResult<T>
{
    public Status Status { get; set; }
    public string Message { get; set; }
    public T? Result { get; set; }

    public CommandResult(Status status, string message, T result)
    {
        this.Status = status;
        Message = message;
        Result = result;
    }

    public CommandResult(Status status, string message)
    {
        this.Status = status;
        Message = message;
    }
}

public class CommandResult
{
    public Status Status { get; set; }
    public string Message { get; set; }

    public CommandResult(Status status, string message)
    {
        this.Status = status;
        Message = message;
    }
}