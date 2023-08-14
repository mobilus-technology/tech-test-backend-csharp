using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TechTest.Domain.Entities;
using TechTest.Domain.Interfaces;
using TechTest.Infrastructure.Context;

namespace TechTest.Infrastructure.Repositories;

public class MongoRepository : IProdutoMongoDbRepository
{
    private readonly IMongoCollection<Produto> _produtoCollection;

    public MongoRepository(IOptions<ProdutoStoreDatabaseSettings> produtoStoreDatabaseSettings)
    {
        var mongoClient = new MongoClient(
        produtoStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            produtoStoreDatabaseSettings.Value.DatabaseName);

        _produtoCollection = mongoDatabase.GetCollection<Produto>(
            produtoStoreDatabaseSettings.Value.ProdutosCollectionName);
    }

    public async Task CreateAsync(Produto produto)
    {
        await _produtoCollection.InsertOneAsync(produto);        
    }

    public async Task GetByIdAsync(int? id)
    {
        await _produtoCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Produto?>> GetProdutosAsync()
    {
        return await _produtoCollection.Find(_ => true).ToListAsync();
    }

    public async Task RemoveAsync(int? id)
    {
        await _produtoCollection.DeleteOneAsync(produto => produto.Id == id);
    }

    public async Task UpdateAsync(int? id, Produto produto)
    {
        await _produtoCollection.ReplaceOneAsync(x => x.Id == id, produto);        
    }
}
