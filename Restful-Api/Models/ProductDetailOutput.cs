namespace Restful_Api.Models;

public class ProductDetailOutput
{
    // Unique identifier for the product
    public int Id { get; set; }

    // Product name
    public string Name { get; set; }

    // Product price
    public decimal Price { get; set; }

    // Product description
    public string Description { get; set; }
}