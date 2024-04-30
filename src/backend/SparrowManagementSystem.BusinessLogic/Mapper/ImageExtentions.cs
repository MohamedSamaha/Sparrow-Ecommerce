using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
	public static class ImageExtentions
	{
		public static ImageDto AsDto(this Image image)
		{
			return new ImageDto()
			{
				ImageName = image.ImageName,
				Id = image.Id,
				ImageFilePath = image.ImageFilePath,
				ProductDto = image.Product.AsDto(),
				CreatedAt = image.CreatedAt,
			
			};
		}
		public static Image AsEntity(this ImageDto imageDto)
		{
			return new Image()
			{
				Id = imageDto.Id,
				ImageName = imageDto.ImageName,
				ImageFilePath = imageDto.ImageFilePath,
				CreatedAt = imageDto.CreatedAt,
				Product = imageDto.ProductDto.AsEntity(),
			};
		}
	}
}
