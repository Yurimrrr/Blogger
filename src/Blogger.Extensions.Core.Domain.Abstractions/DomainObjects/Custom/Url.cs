namespace Blogger.Extensions.Core.Domain.Abstractions.DomainObjects.Custom;

public class Url : ValueObject
{
    private readonly Uri _uri;
    public string Value { get; protected set; }
    public string AbsolutePath => _uri.AbsolutePath;
    public string AbsoluteUri => _uri.AbsoluteUri;
    public string Scheme => _uri.Scheme;
    public string Host => _uri.Host;
    public int Port => _uri.Port;
    public string Query => _uri.Query;

    public Url(string value)
    {
        if (!Uri.TryCreate(value, UriKind.Absolute, out _))
            throw new ArgumentException("Valor da URL inválido.", nameof(value));
            
        _uri = new Uri(value);
        Value = value;
    }
        
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _uri.AbsoluteUri;
    }

    public override string? ToString()
    {
        return _uri.ToString();
    }
}