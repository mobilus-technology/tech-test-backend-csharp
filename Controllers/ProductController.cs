using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var createdProduct = _productService.CreateProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null) return NotFound();

        return product;
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.Id) return BadRequest();

        if (!ModelState.IsValid) return BadRequest(ModelState);

        _productService.UpdateProduct(product);
        return Ok("Produto Atualizado com Sucesso");
    }
    
    [HttpGet("download")]
    public IActionResult DownloadProductsFile()
    {
        var products = _productService.GetAllProducts();
        var json = JsonConvert.SerializeObject(products, Formatting.Indented);
    
        var fileName = "products.txt"; 
        var mimeType = "text/plain";
    
        var bytes = Encoding.UTF8.GetBytes(json);
        var stream = new MemoryStream(bytes);

        return File(stream, mimeType, fileName);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
        return Ok("Produto Deletado com Sucesso");
    }
}
