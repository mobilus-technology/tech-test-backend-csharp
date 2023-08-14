using Microsoft.AspNetCore.Mvc;
using TechTest.Application.DTOs;
using TechTest.Application.Interfaces;

namespace TechTest.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ProdutosController : Controller
{
    private readonly IProdutoService _produtoService;    
    private readonly IProdutoMongoDbService _produtoMongoDbService;
    public ProdutosController(IProdutoService produtoService, IProdutoMongoDbService produtoMongoDbService)
    {
        _produtoService = produtoService;
        _produtoMongoDbService = produtoMongoDbService; 
    }

    // api/produtos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
    {
        var produtos = await _produtoService.GetProdutos();
        return Ok(produtos);
    }

    [HttpGet("{id}", Name = "GetProduto")]
    public async Task<ActionResult<ProdutoDTO>> Get(int id)
    {
        var produto = await _produtoService.GetById(id);

        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> Post(ProdutoDTO produtoDto)
    {
        await _produtoService.Add(produtoDto);

        return new CreatedAtRouteResult("GetProduto",
            new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, ProdutoDTO produtoDto)
    {
        if (id != produtoDto.Id)
        {
            return BadRequest();
        }

        await _produtoService.Update(produtoDto);

        return Ok(produtoDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProdutoDTO>> Delete(int id)
    {
        var produtoDto = await _produtoService.GetById(id);
        if (produtoDto == null)
        {
            return NotFound();
        }
        await _produtoService.Remove(id);
        return Ok(produtoDto);
    }
}
