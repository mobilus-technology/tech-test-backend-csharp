using WebApiProduct.Models;

namespace WebApiProduct.Interface;

public interface IProductRepository
{
    Product Create(Product product);
    Product GetById(int id);
    List<Product> GetAll();
    void Update(Product product);
    void Delete(int id);
}
