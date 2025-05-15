using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(s => s.Customer)
                .NotEmpty()
                .Length(5, 30);

            RuleFor(s => s.Branch)
                .NotEmpty()
                .Length(5, 30);

            RuleFor(s => s.Products)
                .NotNull()
                .NotEmpty();

            RuleForEach(s => s.Products)
                .SetValidator(new CreateProductDTOValidator());
        }
    }
}
