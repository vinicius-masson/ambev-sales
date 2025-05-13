using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        /// <summary>
        /// Tests that when a product has less than 5 items, no discount is applied
        /// The discount should be calculated based on the total price (UnitPrice * Quantity).
        /// </summary>
        [Fact(DisplayName = "Product with quantity less than 5 should have no discount")]
        public void Given_QuantityLessThan5_When_CalculateDiscount_Then_NoDiscountApplied()
        {
            //Arrange
            var product = ProductTestData.GenerateProductWithNoDiscount();
            
            //Act
            product.UpdateQuantity(product.Quantity);

            //Assert
            Assert.Equal(0m, product.Discount);
        }

        /// <summary>
        /// Tests that when a product has between 5 and 9 items, the discount applied is 10%
        /// The discount should be calculated based on the total price (UnitPrice * Quantity).
        /// </summary>
        [Fact(DisplayName = "Product with quantity between 5 and 9 have discount of 10%")]
        public void Given_QuantityBetween5and9_When_CalculateDiscount_Then_Apply10PercentDiscount()
        {
            //Arrange
            var product = ProductTestData.GenerateProductWith10PercentDiscount();

            //Act
            product.UpdateQuantity(product.Quantity);

            //Assert
            Assert.Equal(((product.UnitPrice * product.Quantity) * 0.1m), product.Discount);
        }

        /// <summary>
        /// Tests that when a product has between 10 and 20 items, the discount applied is 20%
        /// The discount should be calculated based on the total price (UnitPrice * Quantity).
        /// </summary>
        [Fact(DisplayName = "Product with quantity between 10 and 20 have discount of 20%")]
        public void Given_QuantityBetween10and20_When_CalculateDiscount_Then_Apply20PercentDiscount()
        {
            //Arrange
            var product = ProductTestData.GenerateProductWith20PercentDiscount();

            //Act
            product.UpdateQuantity(product.Quantity);

            //Assert
            Assert.Equal(((product.UnitPrice * product.Quantity) * 0.2m), product.Discount);
        }

        /// <summary>
        /// Tests that when a product is canceled, their status changes to Cancelled.
        /// </summary>
        [Fact(DisplayName = "Product status should change to Cancelled when cancelled")]
        public void Given_NotCancelledProduct_When_Cancelled_Then_StatusShouldBeCancelled()
        {
            //Arrange
            var product = ProductTestData.GenerateValidProduct();

            //Act
            product.CancelProduct();

            //Assert
            Assert.Equal(ProductStatus.Cancelled, product.Status);
        }

        /// <summary>
        /// Tests that when Unit Price or Quantity is modified, Total Price needs to be recalculated
        /// and match with formula ((UnitPrice * Quantity) - Discount)
        /// </summary>
        [Fact(DisplayName = "TotalPrice should be (UnitPrice * Quantity) minus Discount")]
        public void Given_ValidProduct_When_Calculated_Then_TotalPriceShouldMatchFormula()
        {
            //Arrange
            var product = ProductTestData.GenerateValidProduct();

            //Act
            product.UpdatePrice(product.UnitPrice);
            var expectedTotal = (product.UnitPrice * product.Quantity) - product.Discount;

            //Assert
            Assert.Equal(expectedTotal, product.TotalPrice);
        }
    }
}