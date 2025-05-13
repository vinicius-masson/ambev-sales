using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Product must be at least 5 characters long.")
                .MaximumLength(30).WithMessage("Product cannot be longer than 30 characters.");

            RuleFor(product => product.Quantity)
                .GreaterThan(0)
                .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");

            RuleFor(product => product.UnitPrice).GreaterThan(0);
        }
    }
}
