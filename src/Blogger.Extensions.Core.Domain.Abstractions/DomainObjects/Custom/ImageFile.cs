namespace Blogger.Extensions.Core.Domain.Abstractions.DomainObjects.Custom;

public class ImageFile : ValueObject
{
    public string? Name { get; protected set; }
    public string? Type { get; protected set; }
    public string? Width { get; protected set; }
    public string? Height { get; protected set; }
    public string? Size { get; protected set; }

    public ImageFile(string name, string type, string width, string height, string size) =>
        (Name, Type, Width, Height, Size) = (name, type, width, height, size);

    public ImageFile(string name, string type, string width, string height) =>
        (Name, Type, Width, Height, Size) = (name, type, width, height, "");
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Type;
        yield return Width;
        yield return Height;
        yield return Size;
    }

    public override string? ToString()
    {
        return Name;
    }
}
