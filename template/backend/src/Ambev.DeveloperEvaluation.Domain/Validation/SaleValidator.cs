using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.Customer)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Customer must be at least 5 characters long.")
                .MaximumLength(30).WithMessage("Customer cannot be longer than 30 characters.");


            RuleFor(sale => sale.Branch)
                .NotEmpty()
                .MinimumLength(5).WithMessage("Branch must be at least 5 characters long.")
                .MaximumLength(30).WithMessage("Branch cannot be longer than 30 characters.");

            RuleFor(sale => sale.Products)
                .NotEmpty().WithMessage("Sale must have at least one product.");
        }
    }
}
