using Ambev.DeveloperEvaluation.Application.Products.DTOs;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleCommand : IRequest<CreateSaleResult>
    {
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<CreateProductDTO> Products { get; set; } = new();
    }
}
