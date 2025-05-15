using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DTOs
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Product Id is Required");

            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(5, 30);

            RuleFor(p => p.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);

            RuleFor(p => p.UnitPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.TotalPrice)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(p => p.Discount)
                .NotEmpty();

            RuleFor(p => p.Status)
                .IsInEnum();
        }
    }
}
