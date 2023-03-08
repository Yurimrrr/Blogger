using System.Diagnostics.CodeAnalysis;

namespace Blogger.Extensions.Data.Core.Helpers.Filter
{
    public static class FilterOptions
    {
        internal const DynamicallyAccessedMemberTypes DynamicallyAccessedMembers =
            DynamicallyAccessedMemberTypes.PublicParameterlessConstructor;

        public static readonly string DefaultName = string.Empty;

        public static IFilterOptions<TFilter> Create<[DynamicallyAccessedMembers(DynamicallyAccessedMembers)] TFilter>(
            TFilter filter)
            where TFilter : class
        {
            return new FiltersesWrapper<TFilter>(filter);
        }
    }
}