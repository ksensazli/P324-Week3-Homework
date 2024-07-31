using FluentValidation;
using Restful_Api.Models;

namespace Restful_Api.Validators;

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        // Rule for the Name property: must not be empty
        RuleFor(p => p.Name).NotEmpty().WithMessage("Product name is required.");
            
        // Rule for the Price property: must be greater than zero
        RuleFor(p => p.Price).GreaterThan(0).WithMessage("Product price must be greater than zero.");
            
        // Rule for the Description property: must not be empty
        RuleFor(p => p.Description).NotEmpty().WithMessage("Product description is required.");
    }
}