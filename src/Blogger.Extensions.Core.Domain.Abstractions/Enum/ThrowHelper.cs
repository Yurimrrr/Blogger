namespace Blogger.Extensions.Core.Domain.Abstractions.Enum
{
    public static class ThrowHelper
    {
        public static void ThrowArgumentNullException(string paramName)
            => throw new ArgumentNullException(paramName);

        public static void ThrowArgumentNullOrEmptyException(string paramName)
            => throw new ArgumentException("Argument cannot be null or empty.", paramName);

        public static void ThrowNameNotFoundException<TEnum, TValue>(string name)
            where TEnum : Enumeration<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
            => throw new EnumerationNotFoundException($"No {typeof(TEnum).Name} with Name \"{name}\" found.");

        public static void ThrowValueNotFoundException<TEnum, TValue>(TValue value)
            where TEnum : Enumeration<TEnum, TValue>
            where TValue : IEquatable<TValue>, IComparable<TValue>
            => throw new EnumerationNotFoundException($"No {typeof(TEnum).Name} with Value {value} found.");
    }
}