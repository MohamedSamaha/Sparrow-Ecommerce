using SparrowManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(int Id);
        Task<CategoryDto> CreateCategory(CategoryDto materialDto);
        Task DeleteCategory(int Id);
        Task<CategoryDto> UpdateCategory(CategoryDto materialDto);
    }
}
