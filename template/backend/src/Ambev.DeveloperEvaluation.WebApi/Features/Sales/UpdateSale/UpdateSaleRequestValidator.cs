using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(s => s.Id)
                .NotEmpty()
                .WithMessage("Sale Id is required");

            RuleFor(s => s.Customer)
                .NotEmpty()
                .Length(5, 30);

            RuleFor(s => s.Branch)
                .NotEmpty()
                .Length(5, 30);

            RuleForEach(s => s.Products).SetValidator(new UpdateProductDTOValidator());
        }
    }
}
