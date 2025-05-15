using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestProfile : Profile
    {
        public UpdateSaleRequestProfile()
        {
            CreateMap<UpdateSaleRequest, UpdateSaleCommand>();
            //CreateMap<Sale, UpdateSaleResponse>();
        }
    }
}
