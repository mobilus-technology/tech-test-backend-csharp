using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Context
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

            return _sqlRepository.GetById(id);
        }

        public List<Product> GetAll()
        {

            return _sqlRepository.GetAll();
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
