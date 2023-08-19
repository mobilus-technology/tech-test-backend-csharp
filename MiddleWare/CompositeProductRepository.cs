using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.DbAll;

public class CompositeProductRepository : IProductRepository
{
    private readonly IProductRepository _noSqlRepository;
    private readonly IProductRepository _sqlRepository;
    
    public CompositeProductRepository(
        IProductRepository noSqlRepository,
        IProductRepository sqlRepository
    )
    {
        _noSqlRepository = noSqlRepository;
        _sqlRepository = sqlRepository;
    }
    
    
    public Product Create(Product product)
    {
        var createdProduct = _noSqlRepository.Create(product);
        _sqlRepository.Create(product);
        return createdProduct;
    }


    public Product GetById(int id)
    {
        var product = _noSqlRepository.GetById(id);
        if (product == null)
        {
            product = _sqlRepository.GetById(id);
        }
        
        return product;
    }

    public List<Product> GetAll()
    {
        var noSqlProducts = _noSqlRepository.GetAll();
        var sqlProducts = _sqlRepository.GetAll();
        return noSqlProducts.Concat(sqlProducts).ToList();
    }

    public void Update(Product product)
    {
        _noSqlRepository.Update(product);
        _sqlRepository.Update(product);
    }

    public void Delete(int id)
    {
        _noSqlRepository.Delete(id);
        _sqlRepository.Delete(id);
    }
}
