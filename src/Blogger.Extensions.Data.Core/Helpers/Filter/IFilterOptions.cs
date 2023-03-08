using System.Diagnostics.CodeAnalysis;

namespace Blogger.Extensions.Data.Core.Helpers.Filter
{
    public interface IFilterOptions<[DynamicallyAccessedMembers(FilterOptions.DynamicallyAccessedMembers)] out TFilter>
        where TFilter : class
    {
        TFilter Filter { get; }
    }
}