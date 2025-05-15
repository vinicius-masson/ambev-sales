using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResponse>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public async Task<UpdateSaleResponse> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.Id);
            
            sale.SetCustomer(command.Customer);
            sale.SetBranch(command.Branch);

            if (command.Status.Equals(SaleStatus.Cancelled))
                sale.CancelSale();

            sale.ClearProducts();

            List<Product> products = new List<Product>();

            foreach (var product in command.Products)
                sale.AddProduct(new Product(product.Name, product.Quantity, product.UnitPrice));
            
            var updatedSale = await _saleRepository.UpdateAsync(sale, command.Id, cancellationToken);
            return new UpdateSaleResponse { Success = true };
        }
    }
}
