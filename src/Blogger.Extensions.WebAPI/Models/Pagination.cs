namespace Blogger.Extensions.WebAPI.Models;

public class Pagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalRegister { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
    public int TotalPage => (TotalRegister % PageSize) > 0
        ? (TotalRegister / PageSize) + 1
        : (TotalRegister / PageSize);
}