using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleCommand that defines validation rules for sale creation command.
    /// </summary>
    public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleValidator with defined validation rules.
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Customer: Required, must be between 5 and 30 characters
        /// - Branch: Required, must be between 5 and 30 characters
        /// - Products: Required
        /// </remarks>
        public CreateSaleCommandValidator()
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
