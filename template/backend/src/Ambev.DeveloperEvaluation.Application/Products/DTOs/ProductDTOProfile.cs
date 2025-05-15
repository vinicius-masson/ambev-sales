using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.DTOs
{
    public class ProductDTOProfile : Profile
    {
        public ProductDTOProfile()
        {
            CreateMap<Product,  ProductDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
