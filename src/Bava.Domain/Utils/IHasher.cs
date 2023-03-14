namespace Bava.Domain.Utils;

public interface IHasher
{
    public string Hash(string key);
    public bool Validate(string key, string hashedKey);
}