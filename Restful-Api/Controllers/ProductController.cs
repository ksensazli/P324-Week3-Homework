using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Restful_Api.Models;
using Restful_Api.Services;

namespace Restful_Api.Controllers;

// Define the route for the controller
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IValidator<Product> _productValidator;
    private readonly IValidator<int> _productIdValidator;

    // Constructor to inject the product service and validators
    public ProductController(IProductService productService, IValidator<Product> productValidator, IValidator<int> productIdValidator)
    {
        _productService = productService;
        _productValidator = productValidator;
        _productIdValidator = productIdValidator;
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
        // Validate the product ID
        var validationResult = _productIdValidator.Validate(id);
        if (!validationResult.IsValid)
        {
            // Return 400 if validation fails
            return BadRequest(validationResult.Errors);
        }

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

        // Validate the product model
        var validationResult = _productValidator.Validate(product);
        if (!validationResult.IsValid)
        {
            // Return 400 if validation fails
            return BadRequest(validationResult.Errors);
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

        // Validate the product ID
        var idValidationResult = _productIdValidator.Validate(id);
        if (!idValidationResult.IsValid)
        {
            // Return 400 if validation fails
            return BadRequest(idValidationResult.Errors);
        }

        // Validate the product model
        var productValidationResult = _productValidator.Validate(product);
        if (!productValidationResult.IsValid)
        {
            // Return 400 if validation fails
            return BadRequest(productValidationResult.Errors);
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
        // Validate the product ID
        var validationResult = _productIdValidator.Validate(id);
        if (!validationResult.IsValid)
        {
            // Return 400 if validation fails
            return BadRequest(validationResult.Errors);
        }

        // Delete the product using the service
        _productService.DeleteProduct(id);
        // Return 204 No Content
        return NoContent();
    }
}