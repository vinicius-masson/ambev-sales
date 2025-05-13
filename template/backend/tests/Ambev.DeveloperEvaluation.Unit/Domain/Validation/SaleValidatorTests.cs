using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Bogus.DataSets;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    public class SaleValidatorTests
    {
        private readonly SaleValidator _validator;

        public SaleValidatorTests()
        {
            _validator = new SaleValidator();
        }

        /// <summary>
        /// Tests that validation passes when all sale properties are valid.
        /// This test verifies that a sale with valid:
        /// - Customer (5-30 characters)
        /// - Branch (5-30 characters)
        /// - UnitPrice (greater than 0)
        /// - Status (NotCancelled/Cancelled)
        /// passes all validation rules without any errors.
        /// </summary>
        [Fact(DisplayName = "Valid sale should pass all validation rules")]
        public void Given_ValidSale_When_Validate_Then_ShouldNotHaveErrors()
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();

            //Act
            var result = _validator.TestValidate(sale);

            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that validation fails for invalid sale customer formats.
        /// This test verifies that sale customer that are:
        /// - Empty strings
        /// - Less than 5 characters
        /// fail validation with appropriate error messages.
        /// The sale customer is a required field and must be between 5 and 30 characters.
        /// </summary>
        /// <param name="customer">The invalid product name to test.</param>
        /// </summary>
        [Theory(DisplayName = "Invalid sale customer formats should fail validation")]
        [InlineData("")] // empty
        [InlineData("abcd")] //less than 5
        [InlineData("ThisNameHaveMoreThan30Characters")] //greater than 30
        public void Given_InvalidCustomer_When_Validated_Then_ShouldHaveErrors(string name)
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.SetCustomer(name);

            //Act
            var result = _validator.TestValidate(sale);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Customer);
        }

        /// <summary>
        /// Tests that validation fails for invalid sale branch formats.
        /// This test verifies that sale branch that are:
        /// - Empty strings
        /// - Less than 5 characters
        /// fail validation with appropriate error messages.
        /// The sale branch is a required field and must be between 5 and 30 characters.
        /// </summary>
        /// <param name="branch">The invalid product name to test.</param>
        /// </summary>
        [Theory(DisplayName = "Invalid sale branch formats should fail validation")]
        [InlineData("")] // empty
        [InlineData("abcd")] //less than 5
        [InlineData("ThisNameHaveMoreThan30Characters")] //greater than 30
        public void Given_InvalidBranch_When_Validated_Then_ShouldHaveErrors(string name)
        {
            //Arrange
            var sale = SaleTestData.GenerateValidSale();
            sale.SetBranch(name);

            //Act
            var result = _validator.TestValidate(sale);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Branch);
        }

        ///<summary>
        /// Tests that validation fails for a sale that don't have products
        /// </summary>
        [Fact(DisplayName = "Sale with no products should fail validation")]
        public void Given()
        {
            //Arrange
            var sale = SaleTestData.GenerateSaleWithNoProducts();

            //Act
            var result = _validator.TestValidate(sale);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Products);
        }
    }
}
