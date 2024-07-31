using Restful_Api.Models;

namespace Restful_Api.Services;

public class FakeProductService : IProductService
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Product1", Price = 10.0M, Description = "Description1" },
        new Product { Id = 2, Name = "Product2", Price = 20.0M, Description = "Description2" }
    };

    public IEnumerable<Product> GetProducts(string name, string sort)
    {
        var result = products.AsEnumerable();

        if (!string.IsNullOrEmpty(name))
        {
            result = result.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(sort))
        {
            result = sort switch
            {
                "name" => result.OrderBy(p => p.Name),
                "price" => result.OrderBy(p => p.Price),
                _ => result
            };
        }

        return result;
    }

    public Product GetProduct(int id)
    {
        return products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        product.Id = products.Max(p => p.Id) + 1;
        products.Add(product);
    }

    public void UpdateProduct(int id, Product product)
    {
        var existingProduct = products.FirstOrDefault(p => p.Id == id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
        }
    }

    public void DeleteProduct(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            products.Remove(product);
        }
    }
}