using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class ProductValidatorTests
    {
        private readonly ProductValidator _validator;

        public ProductValidatorTests()
        {
            _validator = new ProductValidator();
        }

        /// <summary>
        /// Tests that validation passes when all product properties are valid.
        /// This test verifies that a product with valid:
        /// - Name (5-30 characters)
        /// - Quantity (1-20 items)
        /// - UnitPrice (greater than 0)
        /// - Status (NotCancelled/Cancelled)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid product should pass all validation rules")]
        public void Given_ValidProduct_When_Validated_Then_ShouldNotHaveErrors()
        {
            //Arrange
            var product = ProductTestData.GenerateValidProduct();

            //Act
            var result = _validator.TestValidate(product);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails for invalid product name formats.
        /// This test verifies that product name that are:
        /// - Empty strings
        /// - Less than 5 characters
        /// fail validation with appropriate error messages.
        /// The username is a required field and must be between 5 and 30 characters.
        /// </summary>
        /// <param name="name">The invalid product name to test.</param>
        [Theory(DisplayName = "Invalid product name formats should fail validation")]
        [InlineData("")] // Empty
        [InlineData("abcd")] // Less than  characters
        public void Given_InvalidProductName_When_Validated_Then_ShouldHaveErrors(string productname)
        {
            //Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.SetName(productname);

            //Act
            var result = _validator.TestValidate(product);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Tests that validation fails when product name exceeds maximum length.
        /// This test verifies that product name longer than 30 characters fail validation.
        /// The test uses TestDataGenerator to create a product name that exceeds the maximum
        /// length limit, ensuring the validation rule is properly enforced.
        /// </summary>
        [Fact(DisplayName = "Product name longer than maximum length should fail validation")]
        public void Given_ProductNameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.SetName(ProductTestData.GenerateInvalidName());

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        /// <summary>
        /// Tests that validation fails for invalid quantity formats.
        /// This test verifies that quantity that:
        /// - Greater than 20
        /// - Less than 1
        /// fail validation with appropriate error messages.
        /// The test uses TestDataGenerator to create invalid quantity formats.
        /// <param name="quantity"/> The invalid quantity to test </param>
        /// </summary>
        [Theory(DisplayName = "Invalid quantity formats should fail validation")]
        [InlineData(0)]
        [InlineData(42)]
        public void Given_InvalidQuantity_When_Validated_Then_ShouldHaveError(int quantity)
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.UpdateQuantity(quantity);

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Quantity);
        }

        /// <summary>
        /// Tests that validation fails for invalid unit price formats.
        /// This test verifies that unit price that:
        /// - Negative or zero
        /// fail validation with appropriate error messages.
        /// </summary>
        [Fact(DisplayName = "Invalid unit price formats should fail validation")]
        public void Given_InvalidUnitPrice_When_Validated_Then_ShouldHaveError()
        {
            // Arrange
            var product = ProductTestData.GenerateValidProduct();
            product.UpdatePrice(ProductTestData.GenerateInvalidUnitPrice());

            // Act
            var result = _validator.TestValidate(product);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.UnitPrice);
        }
    }
}
