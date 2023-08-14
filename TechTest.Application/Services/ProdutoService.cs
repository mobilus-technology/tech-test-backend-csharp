using AutoMapper;
using TechTest.Application.DTOs;
using TechTest.Application.Interfaces;
using TechTest.Domain.Entities;
using TechTest.Domain.Interfaces;

namespace TechTest.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;
    private readonly IMapper _mapper;

    public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository ?? throw new ArgumentNullException(nameof(produtoRepository));
        _mapper = mapper;
    }

    public async Task Add(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.CreateAsync(produto);
    }

    public async Task<ProdutoDTO?> GetById(int? id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        return _mapper.Map<ProdutoDTO>(produto);
    }

    public async Task<IEnumerable<ProdutoDTO?>> GetProdutos()
    {
        var produtos = await _produtoRepository.GetProdutosAsync();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
    }

    public async Task Remove(int? id)
    {
        var produto = _produtoRepository.GetByIdAsync(id).Result;
        await _produtoRepository.RemoveAsync(produto);
    }

    public async Task Update(ProdutoDTO produtoDto)
    {
        var produto = _mapper.Map<Produto>(produtoDto);
        await _produtoRepository.UpdateAsync(produto);
    }
}
