using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesResult
    {
        public List<GetSaleResult> Sales { get; set; } = new();
    }
}
