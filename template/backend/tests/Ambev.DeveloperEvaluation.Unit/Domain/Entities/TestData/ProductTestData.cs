using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;
using Bogus.Extensions;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class ProductTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid product entities.
        /// The generated product will have valid:
        /// - Name (valid format)
        /// - Quantity (valid size)
        /// - Unit Price (valid size)
        /// </summary>
        private static readonly Faker<Product> ProductFaker = new Faker<Product>()
            .CustomInstantiator(f => new Product(
                name: f.Commerce.ProductName().ClampLength(5, 30),
                quantity: f.Random.Int(1, 20),
                unitPrice: f.Random.Decimal(0.01m, 1000)
            ));

        /// <summary>
        /// Generates a valid Product entity with randomized data.
        /// The generated Product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Product entity with randomly generated data.</returns>
        public static Product GenerateValidProduct()
        {
            return ProductFaker.Generate();
        }

        /// <summary>
        /// Generates several valid Products entities with randomized data.
        /// The generated Products will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>Several valid Products entities with randomly generated data.</returns>
        public static List<Product> GenerateValidProductsBetween(int min, int max)
        {
            return ProductFaker.Generate(new Random().Next(min, max + 1));
        }

        /// <summary>
        /// Generates a Product that has no discount
        /// </summary>
        /// <returns>A Product entity without discount</returns>
        public static Product GenerateProductWithNoDiscount()
        {
            return ProductFaker.RuleFor(p => p.Quantity, 3).Generate();
        }

        /// <summary>
        /// Generates a Product that has 10% discount
        /// </summary>
        /// <returns>A Product entity with 10% discount</returns>
        public static Product GenerateProductWith10PercentDiscount()
        {
            return ProductFaker.RuleFor(p => p.Quantity, 7).Generate();
        }

        /// <summary>
        /// Generates a Product that has 20% discount
        /// </summary>
        /// <returns>A Product entity with 20% discount</returns>
        public static Product GenerateProductWith20PercentDiscount()
        {
            return ProductFaker.RuleFor(p => p.Quantity, 14).Generate();
        }

        /// <summary>
        /// Generates a Product that has an invalid quantity
        /// </summary>
        /// <returns>A Product entity with invalid quantity</returns>
        public static Product GenerateProductWithInvalidQuantity()
        {
            return ProductFaker.RuleFor(p => p.Quantity, 25).Generate();
        }

        public static string GenerateInvalidName()
        {
            return new Faker().Name.Random.String(32);
        }

        /// <summary>
        /// Generates an invalid quantity for testing negative scenarios.
        /// The generated quantity will:
        /// - Be greater than 20
        /// - Less than 0
        /// This is useful for testing quantity validation error cases.
        /// </summary>
        /// <returns>An invalid quantity</returns>
        public static int GenerateInvalidQuantity()
        {
            return new Faker().Random.Int(21, 50);
        }

        /// <summary>
        /// Generates an invalid unit price for testing negative scenarios.
        /// The generated unit price will:
        /// - Be greater than 0
        /// This is useful for testing unit price validation error cases.
        /// </summary>
        /// <returns>An invalid unit price</returns>
        public static decimal GenerateInvalidUnitPrice()
        {
            return new Faker().Random.Decimal(-100, 0m);
        }
    }
}
