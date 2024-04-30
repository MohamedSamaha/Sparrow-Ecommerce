using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;

namespace SparrowManagementSystem.Ui.Mapper
{
    public static class CategoryExtensions
    {
        public static CategoryDto AsDto(this Category category)
        {
            return  new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
                Type = category.Type,
                Description = category.Description,
                CreatedBy = category.CreatedBy,
            };
        }
        public static Category AsEntity(this CategoryDto categoryDto)
        {
            return new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                Type = categoryDto.Type,
                Description = categoryDto.Description,
                CreatedBy = categoryDto.CreatedBy,
            };
        }
    }
}
