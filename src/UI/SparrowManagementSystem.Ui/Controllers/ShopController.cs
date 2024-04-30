using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.Core.Interfaces.IServices;

namespace SparrowManagementSystem.Ui.Controllers
{
    [Authorize]
    public class ShopController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;

        public ShopController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
        // GET: ShopController
        public async Task<ActionResult> Index()
		{
			try
			{
				var categories = await _categoryService.GetAllCategories();
				return View(categories);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}
        

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ShopController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ShopController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ShopController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ShopController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ShopController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		
	}
}
