using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product(string name, int quantity, decimal unitPrice)
        {
            Name = name;
            Quantity = quantity;
            UnitPrice = unitPrice;
            Status = ProductStatus.NotCancelled;

            Validate();
            ApplyBusinessRules();
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }
        public decimal TotalPrice { get; private set; }
        public ProductStatus Status { get; private set; }

        public void SetName(string name)
        {
            Name = name;
            Validate();
        }

        private void ApplyBusinessRules()
        {
            CalculateDiscount();
            CalculateTotalPrice();
        }

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public void UpdateQuantity(int quantity)
        {
            Quantity = quantity;
            Validate();
            ApplyBusinessRules();
        }

        public void UpdatePrice(decimal price)
        {
            UnitPrice = price;
            Validate();
            ApplyBusinessRules();
        }

        private void CalculateDiscount()
        {
            decimal totalPrice = UnitPrice * Quantity;

            Discount = Quantity switch
            {
                >= 10 and <= 20 => totalPrice * 0.2m,
                >= 5 and <= 9 => totalPrice * 0.1m,
                _ => 0
            };
        }

        public void CancelProduct() => Status = ProductStatus.Cancelled;

        private void CalculateTotalPrice() => TotalPrice = (UnitPrice * Quantity) - Discount;
    }
}
