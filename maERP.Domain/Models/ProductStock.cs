﻿using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class ProductStock : BaseEntity
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public int WarehouseId { get; set; }

    public Warehouse Warehouse { get; set; } = null!;
    public int Quantity { get; set; } = 0;
}