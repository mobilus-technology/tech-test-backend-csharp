using MongoDB.Driver;
using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Repository;

public class NoSqlProductRepository : IProductRepository
{
    private readonly IMongoCollection<Product> _collection;

    public NoSqlProductRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<Product>("Product");
    }

    public Product Create(Product product)
    {
        _collection.InsertOne(product);
        return product;
    }

    public Product GetById(int id)
    {
        return _collection.Find(p => p.Id == id).FirstOrDefault();
    }

    public List<Product> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public void Update(Product product)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);
        _collection.ReplaceOne(filter, product);
    }

    public void Delete(int id)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, id);
        _collection.DeleteOne(filter);
    }
}
