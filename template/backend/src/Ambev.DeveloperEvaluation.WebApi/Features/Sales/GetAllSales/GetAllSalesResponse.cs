using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales
{
    public class GetAllSalesResponse
    {
        public List<GetSaleResponse> Sales { get; set; } = new List<GetSaleResponse>();
    }
}
