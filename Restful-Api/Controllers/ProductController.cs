using Microsoft.AspNetCore.Mvc;
using Restful_Api.Models;
using Restful_Api.Services;

namespace Restful_Api.Controllers;

// Define the route for the controller
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    // Constructor to inject the product service
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    // GET: api/products
    // Retrieves the list of products, optionally filtered by name and sorted by name or price
    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts([FromQuery] string name, [FromQuery] string sort)
    {
        // Get the products from the service
        var result = _productService.GetProducts(name, sort);
        return Ok(result);
    }

    // GET: api/products/{id}
    // Retrieves a product by its ID
    [HttpGet("{id}")]
    public ActionResult<Product> GetProduct(int id)
    {
        // Get the product from the service
        var product = _productService.GetProduct(id);
        if (product == null)
        {
            // Return 404 if not found
            return NotFound();
        }

        // Return the found product
        return Ok(product);
    }

    // POST: api/products
    // Creates a new product
    [HttpPost]
    public ActionResult<Product> CreateProduct([FromBody] Product product)
    {
        if (product == null)
        {
            // Return 400 if the product is null
            return BadRequest();
        }

        // Add the product using the service
        _productService.AddProduct(product);
        // Return 201 Created with the location of the new product
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

    // PUT: api/products/{id}
    // Updates an existing product
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
        if (product == null || product.Id != id)
        {
            // Return 400 if the product is null or the ID doesn't match
            return BadRequest();
        }

        // Update the product using the service
        _productService.UpdateProduct(id, product);
        // Return 204 No Content
        return NoContent();
    }

    // DELETE: api/products/{id}
    // Deletes a product by its ID
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        // Delete the product using the service
        _productService.DeleteProduct(id);
        // Return 204 No Content
        return NoContent();
    }
}