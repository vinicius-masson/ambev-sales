using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Shared.Pagination;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, PaginatedList<GetSaleResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<PaginatedList<GetSaleResult>> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var query = _saleRepository
                .GetAll(cancellationToken)
                .OrderByDescending(s => s.SaleDate);

            var paginatedSales = await PaginatedList<Sale>.CreateAsync(query, request.PageNumber, request.PageSize);

            var saleResult = _mapper.Map<List<GetSaleResult>>(paginatedSales.Items);

            var teste = new PaginatedList<GetSaleResult>(saleResult, paginatedSales.TotalCount, paginatedSales.CurrentPage, paginatedSales.PageSize);
            return teste;
        }
    }
}
