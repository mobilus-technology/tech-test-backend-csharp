using Newtonsoft.Json;
using WebApiProduct.Interface;
using WebApiProduct.Models;

namespace WebApiProduct.Repository;

public class TextFileProductRepository : IProductRepository
{
    private readonly string _filePath;

    public TextFileProductRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Product Create(Product product)
    {
        var products = GetAllProductsFromFile();
        product.Id = products.Count + 1;
        products.Add(product);
        WriteProductsToFile(products);
        return product;
    }

    public Product GetById(int id)
    {
        var products = GetAllProductsFromFile();
        return products.Find(p => p.Id == id);
    }

    public List<Product> GetAll()
    {
        return GetAllProductsFromFile();
    }

    public void Update(Product product)
    {
        var products = GetAllProductsFromFile();
        var existingProduct = products.Find(p => p.Id == product.Id);
        if (existingProduct != null)
        {
            existingProduct.Nome = product.Nome;
            existingProduct.Preco = product.Preco;
            existingProduct.Estoque = product.Estoque;
        }

        WriteProductsToFile(products);
    }

    public void Delete(int id)
    {
        var products = GetAllProductsFromFile();
        var productToRemove = products.Find(p => p.Id == id);
        if (productToRemove != null)
        {
            products.Remove(productToRemove);
            WriteProductsToFile(products);
        }
    }

    private List<Product> GetAllProductsFromFile()
    {
        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<List<Product>>(json) ?? new List<Product>();
    }

    private void WriteProductsToFile(List<Product> products)
    {
        var json = JsonConvert.SerializeObject(products, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}
