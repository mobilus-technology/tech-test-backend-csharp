using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProduct.Models;

public interface IProduct
{
    int Id { get; }
    string Nome { get; set; }
    decimal Preco { get; set; }
    decimal Estoque { get; set; }
    DateTime Data { get; set; }
}

public class Product : IProduct
{
    [NotMapped]
    public decimal ValorTotal => Math.Round(Preco * Estoque, 2);
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Nome { get; set; }

    [NonNegativeDecimal]
    public decimal Preco { get; set; }

    public decimal Estoque { get; set; }

    public DateTime Data { get; set; }
}

public class ProductService
{
    private readonly IProduct _product;

    public ProductService(IProduct product)
    {
        _product = product;
    }

    public void UpdatePrice(decimal newPrice)
    {
        // Lógica para atualizar o preço do produto
        _product.Preco = newPrice;
    }
}
