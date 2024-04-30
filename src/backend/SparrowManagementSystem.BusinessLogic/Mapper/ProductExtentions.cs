using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitsManagementSystem.BussinessLogic.Logic;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
	public static class ProductExtentions
	{
        public static ProductDto AsDto(this Product product)
		{
			try
			{
                return new ProductDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    BrandName = product.BrandName,
                    ProductCode = product.ProductCode,
                    UnitPrice = product.UnitPrice,
                    Size = product.Size,
                    VendorName = product.VendorName,
                    Color = product.Color,
                    Rating = product.Rating,
                    Details = product.Details,
                    ProductCount = product.ProductCount,
                    Discounts = product.Discounts,
                    MaterialId = product.Material.Id,
                    CategoryId = product.Category.Id,
                    ImageDtos = product.Images.Select(image => image.AsDto()),
                    CreatedAt = product.CreatedAt,
                    CreatedBy = product.CreatedBy
                };
            }
			catch (Exception ex)
			{

				throw ex;
			}
			
		}
		public static Product AsEntity(this ProductDto productDto)
		{
			return new Product()
			{
				Id = productDto.Id,
				Name = productDto.Name,
				Description = productDto.Description,
				BrandName = productDto.BrandName,
				ProductCode = productDto.ProductCode,
				UnitPrice = productDto.UnitPrice,
				Size = productDto.Size,
				VendorName = productDto.VendorName,
				Color = productDto.Color,
				Rating = productDto.Rating,
				Details = productDto.Details,
				ProductCount = productDto.ProductCount,
				Discounts = productDto.Discounts,
				/*Material = productDto.MaterialId,
				Category = productDto.CategoryDto.AsEntity(),*/
				CreatedAt = productDto.CreatedAt,
				CreatedBy = productDto.CreatedBy,
				Images = productDto.ImageDtos.Select(i => i.AsEntity())
			};
		}
	}
}
