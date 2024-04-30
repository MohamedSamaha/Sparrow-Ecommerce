
using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.BusinessLogic.Mapper;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryDto> CreateCategory(CategoryDto categoryDto)
        {
            if (categoryDto != null)
            {
                await _unitOfWork.Categories.CreateAsync(categoryDto.AsEntity());
                _unitOfWork.Save();
            }
            return categoryDto;
        }

        public async Task DeleteCategory(int Id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(Id);
            if (category != null)
            {
                await _unitOfWork.Categories.DeleteAsync(category);
                _unitOfWork.Save();
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var productImages = await _unitOfWork.Products.EntityWithEagerLoad(p => true, new string[] { "Images", "Category", "Material" });
            var allCategories = await _unitOfWork.Categories.EntityWithEagerLoad(c => true, new string[] { "Products" });
            return allCategories.Select(c => c.AsDto());
        }

        public async Task<CategoryDto> GetCategoryById(int Id)
        {
            var productImages = await _unitOfWork.Products.EntityWithEagerLoad(p => true, new string[] { "Images", "Category", "Material" });
            var category = await _unitOfWork.Categories.EntityWithEagerLoad(c => c.Id == Id, new string[] { "Products" });
            return category.FirstOrDefault().AsDto();
        }

        public async Task<CategoryDto> UpdateCategory(CategoryDto categorylDto)
        {
            if (categorylDto != null)
            {
                var updatedCategory = await _unitOfWork.Categories.GetByIdAsync(categorylDto.Id);
                if(updatedCategory != null)
                {
                    updatedCategory.Description = categorylDto.Description;
                    updatedCategory.Name = categorylDto.Name;
                    updatedCategory.Type = categorylDto.Type;
                    updatedCategory.UpdatedAt = categorylDto.UpdatedAt;
                    updatedCategory.UpdatedBy = categorylDto.UpdatedBy;
					await _unitOfWork.Categories.UpdateAsync(updatedCategory);
					_unitOfWork.Save();
				};
                
            }

            return categorylDto;
        }


    }
}
