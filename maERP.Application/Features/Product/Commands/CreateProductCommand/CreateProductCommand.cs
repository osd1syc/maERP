﻿using MediatR;

namespace maERP.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommand : IRequest<int>
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public string Asin { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Msrp { get; set; }
    public int TaxClassId { get; set; }
    public List<int> ProductSalesChannelId { get; set; } = new();
}