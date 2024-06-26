﻿using System.ComponentModel.DataAnnotations;
using maERP.Domain.Models.Common;

namespace maERP.Domain.Models;

public class ShippingProvider : BaseEntity
{
    [Required, Display(Name = "Name")]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<ShippingProviderRate>? ShippingRates { get; set; }
}