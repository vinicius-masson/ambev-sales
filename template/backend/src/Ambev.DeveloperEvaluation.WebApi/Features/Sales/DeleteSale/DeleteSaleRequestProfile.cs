using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class DeleteSaleRequestProfile : Profile
    {
        public DeleteSaleRequestProfile()
        {
            CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
        }
    }
}
