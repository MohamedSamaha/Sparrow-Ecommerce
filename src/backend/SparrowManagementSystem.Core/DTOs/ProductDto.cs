using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.DTOs
{
	public class ProductDto : BaseDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string BrandName { get; set; }
		public int ProductCode { get; set; }
		public decimal UnitPrice { get; set; }
		public string? Size { get; set; }
		public string? VendorName { get; set; }
		public string Color { get; set; }
		public decimal? Rating { get; set; }
		public string? Details { get; set; }
		public int ProductCount { get; set; }
		public decimal? Discounts { get; set; }
		public int MaterialId { get; set; }
		public int CategoryId { get; set; }
		public IEnumerable<ImageDto?>? ImageDtos { get; set; }
	}
}
