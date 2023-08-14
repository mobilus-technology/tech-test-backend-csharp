using TechTest.Domain.Entities;

namespace TechTest.Application.Interfaces;

public interface IProdutoMongoDbService
{
    Task<IEnumerable<Produto?>> GetProdutosAsync();
    Task GetByIdAsync(int? id);
    Task CreateAsync(Produto produto);
    Task UpdateAsync(int? id, Produto produto);
    Task RemoveAsync(int? id);
}
