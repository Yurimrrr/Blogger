namespace Blogger.Extensions.Data.Core.Helpers.Pagination
{
    public interface IPagedListParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; }
    }
}