﻿using maERP.Domain.Models;

namespace maERP.SalesChannels.Models;

public class SalesChannelImportCustomerAddress
{
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNr { get; set; } = string.Empty;
    public string Zip { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public bool DefaultDeliveryAddress { get; set; }
    public bool DefaultInvoiceAddress { get; set; }
    public string Country { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Customer? Customer { get; set; }
    public int CustomerId { get; set; }

    public bool isBillingAddress { get; set; } = false;
    public bool isShippingAddress { get; set; } = false;
}