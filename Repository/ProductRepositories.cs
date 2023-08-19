using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Repository;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Product Create(Product product)
    {
        product.Id = _products.Count + 1;
        product.Data = DateTime.Now;
        _products.Add(product);
        return product;
    }

    public Product GetById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public void Update(Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Nome = product.Nome;
            existingProduct.Preco = product.Preco;
            existingProduct.Estoque = product.Estoque;
        }
    }

    public void Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null) _products.Remove(product);
    }
}
