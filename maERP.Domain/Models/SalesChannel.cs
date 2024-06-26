﻿using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class SalesChannel : BaseEntity
{
    public SalesChannelType Type { get; set; }
    public string Name { get; set; } = string.Empty;
    public string URL { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool ImportProducts { get; set; }
    public bool ImportCustomers { get; set; }
    public bool ImportOrders { get; set; }
    public bool ExportProducts { get; set; }
    public bool ExportCustomers { get; set; }
    public bool ExportOrders { get; set; }

    public int WarehouseId { get; set; } = new();

    // [JsonIgnore]
    public Warehouse Warehouse { get; set; } = new();
}