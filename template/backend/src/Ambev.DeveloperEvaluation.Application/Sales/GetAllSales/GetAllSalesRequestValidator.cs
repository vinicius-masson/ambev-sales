using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesRequestValidator : AbstractValidator<GetAllSalesRequest>
    {
        public GetAllSalesRequestValidator()
        {
            RuleFor(s => s.PageNumber)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(s => s.PageSize)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
