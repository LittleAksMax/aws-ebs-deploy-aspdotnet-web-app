using App.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual required DbSet<Todo> Todos { get; init; }
}