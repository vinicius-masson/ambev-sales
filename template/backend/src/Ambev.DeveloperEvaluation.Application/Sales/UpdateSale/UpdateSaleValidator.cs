using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        public UpdateSaleCommandValidator()
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
