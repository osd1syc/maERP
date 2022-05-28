﻿#nullable disable

using System.ComponentModel.DataAnnotations;

namespace maERP.Data.Models
{
    public class SalesChannel
    {
        [Required]
        public int Id { get; set; }

        [DisplayFormat(NullDisplayText = "No type")]
        public SalesChannelType Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        // [Required]
        // public int WarehouseId { get; set; }

        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool ImportProducts { get; set; }
        public bool ImportCustomers { get; set; }
        public bool ImportOrders { get; set; }
        public bool ExportProducts { get; set; }
        public bool ExportCustomers { get; set; }
        public bool ExportOrders { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual IList<Product> Products { get; set; }
    }

    public enum SalesChannelType
    {
        shopware5, shopware6
    }
}