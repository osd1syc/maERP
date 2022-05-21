﻿#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace maERP.Server.Data
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string SKU { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        // [Required]
        // [Column(TypeName = "money")]
        public Decimal Price { get; set; }

        // [Required]
        [ForeignKey("TaxClass")]
        public int TaxClassId { get; set; }

        public TaxClass TaxClass { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // public ICollection<ProductSalesChannel> ProductSalesChannel { get; set; }
    }
}