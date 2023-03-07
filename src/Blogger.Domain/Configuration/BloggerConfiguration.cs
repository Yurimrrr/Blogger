using Blogger.Domain.Interfaces.Configuration;

namespace Blogger.Domain.Configuration;

public class BloggerConfiguration : IBloggerConfiguration
{
    public string BloggerSqlConnection { get; set; } = string.Empty;
}