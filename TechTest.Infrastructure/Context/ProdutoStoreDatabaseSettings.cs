namespace TechTest.Infrastructure.Context;

public class ProdutoStoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProdutosCollectionName { get; set; } = null!;
}
