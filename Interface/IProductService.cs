using WebApiProduct.Models;

namespace WebApiProduct.Interface;

public interface IProductService
{
    Product CreateProduct(Product product);
    Product GetProductById(int id);
    List<Product> GetAllProducts();
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}
