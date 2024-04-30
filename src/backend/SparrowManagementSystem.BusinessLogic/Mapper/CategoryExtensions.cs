using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
    public static class CategoryExtensions
    {
        public static CategoryDto AsDto(this Category category)
        {
            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Type = category.Type,
                Description = category.Description,
                CreatedBy = category.CreatedBy,
                UpdatedAt = category.UpdatedAt,
                CreatedAt = category.CreatedAt,
                UpdatedBy = category.UpdatedBy,
                DeletedAt = category.DeletedAt,
                DeletedBy = category.DeletedBy,
                productDtos = category.Products.Select(p => p.AsDto())
            };
            if (category.Products != null)
            {
                categoryDto.productDtos = category.Products.Select(p => p.AsDto());
            }
            return categoryDto;
        }
            
        public static Category AsEntity(this CategoryDto categoryDto)
        {
            var category = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Type = categoryDto.Type,
                Description = categoryDto.Description,
                CreatedBy = categoryDto.CreatedBy,
                UpdatedAt = categoryDto.UpdatedAt,
                CreatedAt = categoryDto.CreatedAt,
                UpdatedBy = categoryDto.UpdatedBy,
                DeletedAt = categoryDto.DeletedAt,
                DeletedBy = categoryDto.DeletedBy,
                
            };
            if(categoryDto.productDtos != null)
            {
                category.Products = categoryDto.productDtos.Select(p => p.AsEntity());
            }
            return category;
        }
    }
}
