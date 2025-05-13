using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        ///<summary>
        ///Tests that when a product is added, increases TotalSaleAmount
        ///</summary>
        [Fact(DisplayName = "TotalSaleAmount should increase when a product is added")]
        public void Given_Product_When_Added_Then_TotalSaleAmountShouldIncrease()
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();
            var initialTotal = sale.TotalSaleAmount;
            var product = ProductTestData.GenerateValidProduct();

            //Act
            sale.AddProduct(product);

            //Assert
            Assert.Equal(initialTotal + product.TotalPrice, sale.TotalSaleAmount);
        }

        ///<summary>
        ///Tests that when a product is cancelled, decreases TotalSaleAmount
        ///</summary>
        [Fact(DisplayName = "TotalSaleAmount should decrease when a product is cancelled")]
        public void Given_ProductCancelled_When_CancelProduct_Then_TotalSaleAmountShouldDecrease()
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();
            var initialTotal = sale.TotalSaleAmount;
            var product = sale.Products.First();

            //Act
            sale.CancelProduct(product.Id);

            //Assert
            Assert.Equal(initialTotal - product.TotalPrice, sale.TotalSaleAmount);
        }

        ///<summary>
        ///Tests that when a sale is cancelled, status should be cancelled
        ///</summary>
        [Fact(DisplayName = "Status should be cancelled when sale is cancelled")]
        public void Given_SaleCancelled_When_CancelSale_Then_StatusShouldBeCancelled()
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();

            //Act
            sale.CancelSale();

            //Assert
            Assert.Equal(SaleStatus.Cancelled, sale.Status);
        }
    }
}
