using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public CreateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = new Sale(command.Customer, command.Branch);
            List<Product> products = new List<Product>();

            foreach (var product in command.Products)
                products.Add(new Product(product.Name, product.Quantity, product.UnitPrice));

            products.ForEach(p => sale.AddProduct(p));

            var createdSale = await _saleRepository.CreateAsync(sale);
            var saleResult = _mapper.Map<CreateSaleResult>(createdSale);
            return saleResult;
        }
    }
}
