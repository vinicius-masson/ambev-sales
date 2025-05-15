using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using Bogus.Extensions;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class ProductDtoTestData
    {
        private static readonly Faker<ProductDTO> ProductDTOFaker = new Faker<ProductDTO>()
            .RuleFor(s => s.Name, f => f.Commerce.ProductName().ClampLength(5, 30))
            .RuleFor(s => s.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(s => s.UnitPrice, f =>  f.Random.Decimal(0.01m, 1000));

        /// <summary>
        /// Generates a valid ProductDTOs with randomized data.
        /// The generated Product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid ProductDTOs with randomly generated data.</returns>
        public static ProductDTO GenerateValidProduct()
        {
            return ProductDTOFaker.Generate();
        }

        /// <summary>
        /// Generates several valid ProductDTOs with randomized data.
        /// The generated Products will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>Several valid ProductDTOs with randomly generated data.</returns>
        public static List<ProductDTO> GenerateValidProductsBetween(int min, int max)
        {
            return ProductDTOFaker.Generate(new Random().Next(min, max + 1));
        }
    }
}
