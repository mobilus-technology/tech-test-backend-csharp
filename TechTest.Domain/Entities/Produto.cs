using TechTest.Domain.Validation;

namespace TechTest.Domain.Entities;

public sealed class Produto : Entity
{
    public Produto(string nome, decimal preco, int quantidadeEstoque, DateTime dataCriacao)
    {
        ValidationDomain(nome, preco, quantidadeEstoque, dataCriacao);
    }

    public string? Nome { get; private set; }
    public decimal Preco { get; private set; }
    public decimal ValorTotal => Preco * QuantidadeEstoque;
    public int QuantidadeEstoque { get; private set; }
    public DateTime DataCriacao { get; private set; }

    private void ValidationDomain(string nome, decimal preco, int quantidadeEstoque, DateTime dataCriacao)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório");

        DomainExceptionValidation.When(preco < 0, "Valor do preço inválido");

        DomainExceptionValidation.When(QuantidadeEstoque < 0, "Quantidade de estoque inválido");

        Nome = nome;
        Preco = preco;
        QuantidadeEstoque = quantidadeEstoque;
        DataCriacao = dataCriacao;
    }
}
