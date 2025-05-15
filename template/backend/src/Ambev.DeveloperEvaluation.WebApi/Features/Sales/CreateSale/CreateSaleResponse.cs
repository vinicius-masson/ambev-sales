using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleResponse
    {
        public long Number { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalSaleAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new List<Product>();
        public SaleStatus Status { get; set; }
    }
}
