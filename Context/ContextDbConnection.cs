using Microsoft.EntityFrameworkCore;
using WebApiProduct.Models;

namespace WebApiProduct.Context
{
    public class ContextDbConnection : DbContext
    {
        public ContextDbConnection(DbContextOptions<ContextDbConnection> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Preco).IsRequired();

                entity.HasIndex(p => p.Nome).IsUnique();
            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
