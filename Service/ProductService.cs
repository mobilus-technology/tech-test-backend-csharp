using System.Text;
using WebApiProduct.Interface;
using WebApiProduct.Models;
using WebApiProduct.Repository;

namespace WebApiProduct.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Product CreateProduct(Product product)
    {
        if (product.Preco < 0) throw new ArgumentException("O preço do produto não pode ser negativo.");

        product.Data = DateTime.Now;

        _productRepository.Create(product);

        return product;
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetById(id);
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAll();
    }

    public void UpdateProduct(Product product)
    {
        if (product.Preco < 0) throw new ArgumentException("O preço do produto não pode ser negativo.");

        _productRepository.Update(product);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(id);
    }
}
