using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public long Number { get; set; }
        public DateTime SaleDate { get; set; }
        public string Customer { get; set; } = string.Empty;
        public decimal TotalSaleAmount { get; set; }
        public string Branch { get; set; } = string.Empty;
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
        public string Status { get; set; } = string.Empty;
    }
}
