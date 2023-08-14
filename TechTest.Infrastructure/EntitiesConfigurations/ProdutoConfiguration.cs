using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechTest.Domain.Entities;

namespace TechTest.Infrastructure.EntitiesConfigurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(produto => produto.Id);
        builder.Property(produto => produto.Preco).HasPrecision(10, 2);
        builder.Property(produto => produto.ValorTotal).HasPrecision(10, 2);
        builder.Property(produto => produto.Nome).HasMaxLength(100).IsRequired();
        builder.Property(produto => produto.QuantidadeEstoque).IsRequired();
        builder.Property(produto => produto.DataCriacao).IsRequired();
    }
}
