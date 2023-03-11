using Blogger.Extensions.Core.Domain.Abstractions.DomainObjects;

namespace Blogger.Domain.Entities;

public class Usuario : Entity<Guid>
{
    public Usuario(Guid id) : base(id)
    {
    }

    public string Nome { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public string AvatarUrl { get; set; }
    
}