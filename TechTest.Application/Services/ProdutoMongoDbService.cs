using TechTest.Application.Interfaces;
using TechTest.Domain.Entities;
using TechTest.Domain.Interfaces;

namespace TechTest.Application.Services;

public class ProdutoMongoDbService : IProdutoMongoDbService
{
    private readonly IProdutoMongoDbRepository _produtoMongoDbRepository;

    public ProdutoMongoDbService(IProdutoMongoDbRepository produtoMongoDbRepository)
    {
        _produtoMongoDbRepository = produtoMongoDbRepository;
    }

    public async Task CreateAsync(Produto produto)
    {
        await _produtoMongoDbRepository.CreateAsync(produto);
    }

    public async Task GetByIdAsync(int? id)
    {
        await _produtoMongoDbRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Produto?>> GetProdutosAsync()
    {
        return await _produtoMongoDbRepository.GetProdutosAsync();
    }

    public async Task RemoveAsync(int? id)
    {
        await _produtoMongoDbRepository.RemoveAsync(id);
    }

    public async Task UpdateAsync(int? id, Produto produto)
    {
        await _produtoMongoDbRepository.UpdateAsync(id, produto);
    }
}
