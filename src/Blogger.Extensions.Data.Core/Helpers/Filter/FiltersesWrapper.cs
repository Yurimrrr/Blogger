using System.Diagnostics.CodeAnalysis;

namespace Blogger.Extensions.Data.Core.Helpers.Filter
{
    public class FiltersesWrapper<[DynamicallyAccessedMembers(FilterOptions.DynamicallyAccessedMembers)] TFilter> :
        IFilterOptions<TFilter> where TFilter : class
    {
        public FiltersesWrapper(TFilter options)
        {
            Filter = options;
        }

        /// <summary>
        ///     The options instance.
        /// </summary>
        public TFilter Filter { get; }
    }
}