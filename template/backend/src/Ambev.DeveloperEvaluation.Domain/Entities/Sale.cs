using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public Sale(string customer, string branch)
        {
            Customer = customer;
            Branch = branch;

            Number = new Random().Next();
            Status = SaleStatus.NotCancelled;
            SaleDate = DateTime.UtcNow;
            Products = new List<Product>();
        }

        public long Number { get; private set; }
        public DateTime SaleDate { get; private set; }
        public string Customer { get; private set; }
        public decimal TotalSaleAmount { get; private set; }
        public string Branch { get; private set; }
        public List<Product> Products { get; private set; }
        public SaleStatus Status { get; private set; }

        public void SetCustomer(string customer) => Customer = customer;

        public void SetBranch(string branch) => Branch = branch;

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);

            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
        public void CancelSale()
        {
            Status = SaleStatus.Cancelled;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            product.Sale = this;
            CalculateTotalSale();
        }

        public void CancelProduct(Guid productId)
        {
            var product = Products.FirstOrDefault(p => p.Id == productId);
            if (product == null || product.Status == ProductStatus.Cancelled)
                throw new DomainException("Product not found or already cancelled");

            product.CancelProduct();
            CalculateTotalSale();
        }

        public void ClearProducts() => Products.Clear();

        private void CalculateTotalSale() => TotalSaleAmount = Products.Where(x => x.Status == ProductStatus.NotCancelled).Sum(x => x.TotalPrice);
    }
}
