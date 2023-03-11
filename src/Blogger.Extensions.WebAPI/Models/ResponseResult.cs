namespace Blogger.Extensions.WebAPI.Models;

public class ResponseResult
{
    private IList<string> _validations = new List<string>();

    public static ResponseResult Ok => new ResponseResult();
    public static ResponseResult Error => new ResponseResult();
    public bool IsSuccess { get; protected set; } = false;
    public string?  Message { get; protected set; }
    public int? ResultCount { get; protected set; }
    public Pagination? Pagination { get; protected set; }
    public bool HasValidation => _validations.Count > 0;
    public IList<string> Validations => _validations;
    public object? Data { get; protected set; }

    protected ResponseResult()
    {
        IsSuccess = true;
    }
    
    protected ResponseResult(object? data)
    {
        IsSuccess = true;
        Data = data;
    }
    
    protected ResponseResult(object? data, int? resultCount = 0, Pagination? pagination = null, string? message = "")
        : this(data)
    {
        Message = message;
        ResultCount = resultCount;
        Pagination = pagination;
    }

    protected ResponseResult(string? errorMessage)
    {
        Message = errorMessage;
        IsSuccess = false;
    }

    public static ResponseResult ResponseResultFactory(object? data, int? resultCount, Pagination? pagination = null) =>
        new(data, resultCount, pagination);

    public static ResponseResult ResponseResultFactory(string? errorMessage) =>
        new(errorMessage);
    
    public void AddValidation(string validation) => _validations.Add(validation);
}