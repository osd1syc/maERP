﻿using maERP.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace maERP.Domain.Models;

[Index(nameof(Sku), IsUnique = true)]
public class Product : BaseEntity
{
    public string Sku { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Ean { get; set; } = string.Empty;
    public string Asin { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Msrp { get; set; }
    public decimal Weight { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public decimal Depth { get; set; }

    public int TaxClassId { get; set; }
    public TaxClass? TaxClass { get; set; }

    public ICollection<ProductSalesChannel>? ProductSalesChannels { get; set; } = [];

    public ICollection<ProductStock> ProductStocks { get; set; } = [];
}