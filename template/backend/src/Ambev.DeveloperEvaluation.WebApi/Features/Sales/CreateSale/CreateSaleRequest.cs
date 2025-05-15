﻿using Ambev.DeveloperEvaluation.Application.Products.DTOs;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public string Customer { get; set; } = string.Empty;
        public string Branch { get; set; } = string.Empty;
        public List<CreateProductDTO> Products { get; set; } = new();
    }
}
