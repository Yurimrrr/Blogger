using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bava.Domain.Entities;

namespace Bava.Infra.Context;

public class BavaContext : DbContext
{
    #pragma warning disable CS8618
    public BavaContext(DbContextOptions<BavaContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>();

        modelBuilder.Entity<Blog>().HasMany(b => b.Posts)
            .WithOne(c => c.Blog)
            .HasForeignKey(u => u.BlogId);
        modelBuilder.Entity<Blog>().HasOne(b => b.Owner)
            .WithOne();

        modelBuilder.Entity<Post>().HasOne(b => b.Blog)
            .WithMany(c => c.Posts);
        modelBuilder.Entity<Post>().HasMany(b => b.Categories)
            .WithMany(c => c.Posts);

        modelBuilder.Entity<Category>().HasMany(b => b.Posts)
            .WithMany(c => c.Categories);
    }
}