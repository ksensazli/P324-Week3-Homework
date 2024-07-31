using Restful_Api.Models;

namespace Restful_Api.Services;

public interface IProductService
{
    IEnumerable<Product> GetProducts(string name, string sort);
    Product GetProduct(int id);
    void AddProduct(Product product);
    void UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
}