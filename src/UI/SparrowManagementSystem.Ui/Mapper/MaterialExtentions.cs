using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;

namespace SparrowManagementSystem.Ui.Mapper
{
	public static class MaterialExtentions
	{
		public static MaterialDto AsDto(this Material material)
		{
			return new MaterialDto()
			{
				Id = material.Id,
				SupplierName = material.SupplierName,
				Name = material.Name,
				MaterialCode = material.MaterialCode,
				Type = material.Type,
				CreatedBy = material.CreatedBy,

			};
		}
		public static Material AsEntity(this MaterialDto materialDto)
		{
			return new Material()
			{
				Id = materialDto.Id,
				Name = materialDto.Name,
				Type = materialDto.Type,
				MaterialCode = materialDto.MaterialCode,
				SupplierName = materialDto.SupplierName,
				Description = materialDto.Description,
				CreatedBy = materialDto.CreatedBy,
			};
		}
	}
}
