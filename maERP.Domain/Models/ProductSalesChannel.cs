﻿using System.ComponentModel.DataAnnotations;
using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class ProductSalesChannel : BaseEntity
{
    public SalesChannel SalesChannel { get; set; } = new();
    public int SalesChannelId { get; set; }
    public int ProductId { get; set; } = new();
    public Product Product { get; set; } = new();
    public int RemoteProductId { get; set; }
    public decimal Price { get; set; }
}