using Bava.Domain.Entities;
using Bava.Domain.Handlers;
using Bava.Domain.Repositories;
using Bava.Infra.Context;
using Bava.Infra.Repositories;
using Bava.Infra.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BavaContext>(opt => opt
    .UseSqlServer("Server=localhost,1433;Database=Bava;User ID=sa;Password=1q2w3e4r!;Trusted_Connection=False; TrustServerCertificate=True;"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddTransient<CategoryHandler>();
builder.Services.AddTransient<UserHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();