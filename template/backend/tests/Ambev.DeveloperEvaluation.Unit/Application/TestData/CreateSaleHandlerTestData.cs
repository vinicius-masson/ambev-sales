using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using Bogus.Extensions;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateSaleHandlerTestData
    {
        private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
            .RuleFor(s => s.Customer, f => f.Name.FullName().ClampLength(5, 30))
            .RuleFor(s => s.Branch, f => f.Company.CompanyName().ClampLength(5, 30));

        public static CreateSaleCommand GenerateValidCommand()
        {
            var saleCommand = createSaleHandlerFaker.Generate();
            var productDTO = CreateProductDTOTestData.GenerateValidProductsBetween(1, 5);

            saleCommand.Products = productDTO;
            return saleCommand;
        }

        public static CreateSaleCommand GenerateSaleCommandWithNoProducts()
        {
            return createSaleHandlerFaker.Generate();
        }
    }
}