﻿#nullable disable

namespace maERP.Server.Models
{
	public class CreateProductDto : BaseProductDto
	{
		public string Description { get; set; }
		public DateTime UpdatedAt = DateTime.Now;
		public DateTime CreatedAt = DateTime.Now;
	}
}