﻿namespace maERP.Shared.Dtos.Product;

public class ProductListDto : ProductBaseDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}