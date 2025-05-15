using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, GetAllSalesResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<GetAllSalesResult> Handle(GetAllSalesCommand request, CancellationToken cancellationToken)
        {
            var sale = await _saleRepository.GetAllAsync(cancellationToken);

            var saleResult = _mapper.Map<List<GetSaleResult>>(sale);
            return new GetAllSalesResult { Sales = saleResult };
        }
    }
}
