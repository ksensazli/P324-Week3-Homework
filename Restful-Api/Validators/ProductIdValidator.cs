using FluentValidation;

namespace Restful_Api.Validators;

public class ProductIdValidator : AbstractValidator<int>
{
    public ProductIdValidator()
    {
        // Rule for the ID: must be greater than zero
        RuleFor(id => id).GreaterThan(0).WithMessage("Product ID must be greater than zero.");
    }
}