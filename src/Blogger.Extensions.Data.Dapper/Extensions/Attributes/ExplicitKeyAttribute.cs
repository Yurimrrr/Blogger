namespace Blogger.Extensions.Data.Dapper.Extensions.Attributes;

/// <summary>
/// Specifies that this field is an explicitly set primary key in the database
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class ExplicitKeyAttribute : Attribute
{
}