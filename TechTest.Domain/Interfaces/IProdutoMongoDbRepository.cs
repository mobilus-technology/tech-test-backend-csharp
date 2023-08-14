using TechTest.Domain.Entities;

namespace TechTest.Domain.Interfaces;

public interface IProdutoMongoDbRepository
{
    Task<IEnumerable<Produto?>> GetProdutosAsync();
    Task GetByIdAsync(int? id);
    Task CreateAsync(Produto produto);
    Task UpdateAsync(int? id, Produto produto);
    Task RemoveAsync(int? id);
}
