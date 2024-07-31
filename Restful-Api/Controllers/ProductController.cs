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
    private readonly IValidator<ProductUpdateInput> _productUpdateValidator;
    private readonly IValidator<int> _productIdValidator;

    // Constructor to inject the product service and validators
    public ProductController(IProductService productService, IValidator<ProductUpdateInput> productUpdateValidator, IValidator<int> productIdValidator)
    {
        _productService = productService;
        _productUpdateValidator = productUpdateValidator;
        _productIdValidator = productIdValidator;
    }

    // GET: api/products
    // Retrieves the list of products, optionally filtered by name and sorted by name or price
    [HttpGet]
    public ActionResult<IEnumerable<ProductDetailOutput>> GetProducts([FromQuery] string name, [FromQuery] string sort)
    {
        // Retrieve the products from the service
        var result = _productService.GetProducts(name, sort);
        
        // Map the result to ProductDetailOutput
        var output = result.Select(p => new ProductDetailOutput
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description
        });

        // Return the list of products
        return Ok(output);
    }

    // GET: api/products/{id}
    // Retrieves a product by its ID
    [HttpGet("{id}")]
    public ActionResult<ProductDetailOutput> GetProduct(int id)
    {
        // Validate the product ID
        var validationResult = _productIdValidator.Validate(id);
        if (!validationResult.IsValid)
        {
            // Return 400 Bad Request if validation fails
            return BadRequest(validationResult.Errors);
        }

        // Retrieve the product from the service
        var product = _productService.GetProduct(id);
        if (product == null)
        {
            // Return 404 Not Found if the product is not found
            return NotFound();
        }

        // Map the product to ProductDetailOutput
        var output = new ProductDetailOutput
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        // Return the product details
        return Ok(output);
    }

    // POST: api/products
    // Creates a new product
    [HttpPost]
    public ActionResult<ProductDetailOutput> CreateProduct([FromBody] ProductUpdateInput productInput)
    {
        if (productInput == null)
        {
            // Return 400 Bad Request if the input is null
            return BadRequest();
        }

        // Validate the product input
        var validationResult = _productUpdateValidator.Validate(productInput);
        if (!validationResult.IsValid)
        {
            // Return 400 Bad Request if validation fails
            return BadRequest(validationResult.Errors);
        }

        // Map the input to a new Product entity
        var product = new Product
        {
            Name = productInput.Name,
            Price = productInput.Price,
            Description = productInput.Description
        };

        // Add the product using the service
        _productService.AddProduct(product);

        // Map the product to ProductDetailOutput
        var output = new ProductDetailOutput
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Description = product.Description
        };

        // Return 201 Created with the location of the new product
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, output);
    }

    // PUT: api/products/{id}
    // Updates an existing product
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateInput productInput)
    {
        if (productInput == null || id <= 0)
        {
            // Return 400 Bad Request if the input is null or ID is invalid
            return BadRequest();
        }

        // Validate the product ID
        var idValidationResult = _productIdValidator.Validate(id);
        if (!idValidationResult.IsValid)
        {
            // Return 400 Bad Request if validation fails
            return BadRequest(idValidationResult.Errors);
        }

        // Validate the product input
        var productValidationResult = _productUpdateValidator.Validate(productInput);
        if (!productValidationResult.IsValid)
        {
            // Return 400 Bad Request if validation fails
            return BadRequest(productValidationResult.Errors);
        }

        // Map the input to an updated Product entity
        var product = new Product
        {
            Id = id,
            Name = productInput.Name,
            Price = productInput.Price,
            Description = productInput.Description
        };

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
            // Return 400 Bad Request if validation fails
            return BadRequest(validationResult.Errors);
        }

        // Delete the product using the service
        _productService.DeleteProduct(id);

        // Return 204 No Content
        return NoContent();
    }
}