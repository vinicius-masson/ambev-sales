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
    public static class SaleTestData
    {
        /// <summary>
        /// Configures the Faker to generate valid sale entities.
        /// The generated sale will have valid:
        /// - Customer (valid format)
        /// - Branch (valid size)
        /// </summary>
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .CustomInstantiator(f => new Sale
            (
                customer: f.Name.FullName().ClampLength(5, 30),
                branch: f.Company.CompanyName().ClampLength(5, 30)
            ));

        /// <summary>
        /// Generates a valid Sale entity with randomized data.
        /// The generated Sale will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Sale entity with randomly generated data.</returns>
        public static Sale GenerateValidSale()
        {
            var sale = SaleFaker.Generate();
            var product = ProductTestData.GenerateValidProductsBetween(1, 5);

            product.ForEach(p => sale.AddProduct(p));
            return sale;
        }

        // <summary>
        /// <summary>
        /// Generates a Sale entity without products.
        /// </summary>
        /// <returns>A Sale entity without products.</returns>
        public static Sale GenerateSaleWithNoProducts()
        {
            return SaleFaker.Generate();
        }
    }
}
