using WebApiProduct.Context;
using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Repository;

public class SqlProductRepository : IProductRepository
{
    private readonly ContextDbConnection _dbContext;

    public SqlProductRepository(ContextDbConnection dbContext)
    {
        _dbContext = dbContext;
    }

    public Product Create(Product product)
    {
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return product;
    }

    public Product GetById(int id)
    {
        return _dbContext.Products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetAll()
    {
        return _dbContext.Products.ToList();
    }

    public void Update(Product product)
    {
        var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Nome = product.Nome;
            existingProduct.Preco = product.Preco;
            existingProduct.Estoque = product.Estoque;
            _dbContext.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var productToRemove = _dbContext.Products.FirstOrDefault(p => p.Id == id);
        if (productToRemove != null)
        {
            _dbContext.Products.Remove(productToRemove);
            _dbContext.SaveChanges();
        }
    }
}
