using Blogger.Domain.Entities;
using Blogger.Infra.Data.EFCore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogger.Infra.Data.EFCore.Configurations;

public class UsuarioMapConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario", BloggerContext.DEFAULT_SCHEMA);
        
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");
        builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(255)");
        builder.Property(p => p.Senha)
            .ValueGeneratedOnAdd()
            .HasColumnName("Senha")
            .HasColumnType("varchar(255)");
        builder.Property(p => p.Email)
            .ValueGeneratedOnAdd()
            .HasColumnName("Email")
            .HasColumnType("varchar(255)");
        builder.Property(p => p.AvatarUrl)
            .ValueGeneratedOnAdd()
            .HasColumnName("AvatarUrl")
            .HasColumnType("varchar(255)");
    }
}