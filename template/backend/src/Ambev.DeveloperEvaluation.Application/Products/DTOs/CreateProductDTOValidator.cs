using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.DTOs
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {

            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(5, 30);

            RuleFor(p => p.Quantity)
                .NotEmpty()
                .InclusiveBetween(1, 20);

            RuleFor(p => p.UnitPrice)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
