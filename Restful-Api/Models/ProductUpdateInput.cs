namespace Restful_Api.Models;

public class ProductUpdateInput
{
    // Product name
    public string Name { get; set; }

    // Product price
    public decimal Price { get; set; }

    // Product description
    public string Description { get; set; }
}