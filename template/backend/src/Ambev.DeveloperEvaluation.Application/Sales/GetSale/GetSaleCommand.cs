﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale
{
    public class GetSaleCommand : IRequest<GetSaleResult>
    {
        public Guid Id { get; set; }
    }
}
