using System.Collections.Generic;
using WebApiProduct.Models;

namespace WebApiProduct.Interface
{
    public class DualProductRepository : IProductRepository
    {
        private readonly IProductRepository _sqlRepository;
        private readonly IProductRepository _noSqlRepository;

        public DualProductRepository(IProductRepository sqlRepository, IProductRepository noSqlRepository)
        {
            _sqlRepository = sqlRepository;
            _noSqlRepository = noSqlRepository;
        }

        public Product Create(Product product)
        {
            var createdProductSql = _sqlRepository.Create(product);
            var createdProductNoSql = _noSqlRepository.Create(product);

            return createdProductSql;
        }

        public Product GetById(int id)
        {
            var productFromSql = _sqlRepository.GetById(id);

            if (productFromSql == null)
            {
                productFromSql = _noSqlRepository.GetById(id);
            }

            return productFromSql;
        }

        public List<Product> GetAll()
        {
            var productsFromSql = _sqlRepository.GetAll();
            var productsFromNoSql = _noSqlRepository.GetAll();

            var combinedProducts = new List<Product>();
            combinedProducts.AddRange(productsFromSql);
            combinedProducts.AddRange(productsFromNoSql);

            return combinedProducts;
        }

        public void Update(Product product)
        {
            _sqlRepository.Update(product);
            _noSqlRepository.Update(product);
        }

        public void Delete(int id)
        {
            _sqlRepository.Delete(id);
            _noSqlRepository.Delete(id);
        }
    }
}
