
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;

namespace SparrowManagementSystem.Ui.Controllers
{
    [Authorize(Roles = UserRole.Role_User_Admin)]
    public class CategoryController : Controller
    {
       
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public IEnumerable<CategoryDto> categories { get; set; }
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            categories = await _categoryService.GetAllCategories();
            
            return View(categories);
        }
        // POST: MaterialController/Create
        [HttpPost]
        public async Task<IActionResult> Create(string categoryName, string categoryType, string categoryDescription)
        {
            if (categoryName != null && categoryType != null && categoryDescription != null)
            {
                var categoryDto = new CategoryDto()
                {
                    Name = categoryName,
                    Type = categoryType,
                    Description = categoryDescription,
                    CreatedBy = 1,
                    CreatedAt = DateTime.Now,
                };

                await _categoryService.CreateCategory(categoryDto);
            }
			return RedirectToAction("Index");
		}
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id != null)
            {
                var categoryId = int.Parse(Id);
                await _categoryService.DeleteCategory(categoryId);
            }
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> Edit(string categoryName, string categoryType, string categoryDescription, string Id)
		{
            try
            {
                if (Id != null)
			    {
				    var categoryId = int.Parse(Id);
                    var categoryDto = await _categoryService.GetCategoryById(categoryId);

                    categoryDto.Description = categoryDescription;
                    categoryDto.Name = categoryName;
                    categoryDto.Type = categoryType;
                    categoryDto.UpdatedAt = DateTime.Now;
                    await _categoryService.UpdateCategory(categoryDto);
			    }
			    return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                throw e;
            }
			
		}
	}
   
}
