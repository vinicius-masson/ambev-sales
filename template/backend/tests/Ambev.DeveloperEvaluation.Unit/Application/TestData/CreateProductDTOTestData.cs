using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Bogus;
using Bogus.Extensions;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateProductDTOTestData
    {
        private static readonly Faker<CreateProductDTO> CreateProductDTOFaker = new Faker<CreateProductDTO>()
            .RuleFor(s => s.Name, f => f.Commerce.ProductName().ClampLength(5, 30))
            .RuleFor(s => s.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(s => s.UnitPrice, f => f.Random.Decimal(0.01m, 1000));

        /// <summary>
        /// Generates a valid ProductDTOs with randomized data.
        /// The generated Product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid ProductDTOs with randomly generated data.</returns>
        public static CreateProductDTO GenerateValidProduct()
        {
            return CreateProductDTOFaker.Generate();
        }

        /// <summary>
        /// Generates several valid ProductDTOs with randomized data.
        /// The generated Products will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>Several valid ProductDTOs with randomly generated data.</returns>
        public static List<CreateProductDTO> GenerateValidProductsBetween(int min, int max)
        {
            return CreateProductDTOFaker.Generate(new Random().Next(min, max + 1));
        }
    }
}
