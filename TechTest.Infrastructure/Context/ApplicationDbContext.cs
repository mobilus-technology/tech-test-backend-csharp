using Microsoft.EntityFrameworkCore;
using TechTest.Domain.Entities;

namespace TechTest.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
