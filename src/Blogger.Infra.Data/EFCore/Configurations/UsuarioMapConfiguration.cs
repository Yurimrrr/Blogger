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
            .HasColumnType("int");
    }
}