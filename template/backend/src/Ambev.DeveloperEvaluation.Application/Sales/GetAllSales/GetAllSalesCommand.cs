using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Shared.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesCommand : IRequest<PaginatedList<GetSaleResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
