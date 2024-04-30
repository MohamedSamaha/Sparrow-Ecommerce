using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.Models;
using SparrowManagementSystem.Ui.ViewModel;
using System.Diagnostics;
using System.Security.Claims;

namespace SparrowManagementSystem.Ui.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppThemeService _appThemeService;
        private readonly ICartService _cartService;
		private readonly IWebHostEnvironment _environment;
        private readonly ICategoryService _categoryService;
        public HomeController(ICartService cartService, ICategoryService categoryService, ILogger<HomeController> logger, IAppThemeService appThemeService, IWebHostEnvironment environment)
        {
            _cartService = cartService;
            _categoryService = categoryService;
            _logger = logger;
			_appThemeService = appThemeService;
			_environment = environment;
		}

        public async Task<IActionResult> Index()
        {
			try
			{
				var homePageVM = new HomePageCategoriesRepresentationViewModel()
				{
					AppTheme = await _appThemeService.GetTheCurrentTheme(),
					Categories = await _categoryService.GetAllCategories()
				};

                //// To Get Current Logged In User Id.

                var claims = (ClaimsIdentity)User.Identity;
                var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

                var itemsInCart = await _cartService.GetCartByUserId(Guid.Parse(userId));

				ViewBag.ItemsInCart = itemsInCart.Count();
				

                return View(homePageVM);
            }
			catch (Exception ex)
			{

				throw ex;
			}
			
        }

        public async Task<IActionResult> HomeTheme()
		{
            var allAppTheme = await _appThemeService.GetAllAppThemes();
			return View(allAppTheme);
		}

		public async Task<IActionResult> AddHomeTheme(AddProductTheme addProductTheme)
		{
            try
            {
                await _appThemeService.SetTheme(addProductTheme.setState);

				if (addProductTheme.homeImage != null && addProductTheme.logoImage != null)
				{
					// Check if the uploaded file is an image
					if (!addProductTheme.homeImage.ContentType.StartsWith("image") || !addProductTheme.logoImage.ContentType.StartsWith("image"))
					{
						ModelState.AddModelError("Image", "Please upload a valid image file.");
						return View();
					}

					var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "SparrowImageUploads");
					var homeImageFileName = $"{Guid.NewGuid().ToString()}_{addProductTheme.homeImage.FileName}";
					var logoImageFileName = $"{Guid.NewGuid().ToString()}_{addProductTheme.logoImage.FileName}";
					// file path
					var homeImageFilePath = Path.Combine(uploadsFolder, homeImageFileName);
					var logoImageFilePath = Path.Combine(uploadsFolder, logoImageFileName);

					var stream = new FileStream(homeImageFilePath, FileMode.Create);
					var stream1 = new FileStream(logoImageFilePath, FileMode.Create);
					
					await addProductTheme.homeImage.CopyToAsync(stream);
					await addProductTheme.logoImage.CopyToAsync(stream1);


					// You can save the file path to a database or do other operations here.
					var appThemeDto = new AppThemeDto()
					{
						NavBarColor = addProductTheme.logoColor,
						NavBarLogoFilePath = logoImageFilePath,
						NavBarLogoFileName = logoImageFileName,
						HomePageImageFilePath = homeImageFilePath,
						HomePageImageName = homeImageFileName,
						SubTitle = addProductTheme.subtitle,
						Title = addProductTheme.title,
						MainTitle = addProductTheme.mainTitle,
						HighLight = addProductTheme.highLight,
						setState = addProductTheme.setState,
						CreatedAt = DateTime.Now,
						CreatedBy = 1
					};
					await _appThemeService.CreateAppTheme(appThemeDto);
					
				}
				return RedirectToAction("HomeTheme");
			}
            catch (Exception ex)
            {

                throw ex;
            }
			
		}

		public async Task<IActionResult> EditHomeTheme(int Id)
		{
			try
			{
				if (Id != null)
				{
					await _appThemeService.SetTheme(true);
					await _appThemeService.UpdateSetTheme(Id);
				} 
				return RedirectToAction("HomeTheme");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}
		public async Task<IActionResult> DeleteTheme(int Id)
		{
			try
			{
				if (Id != null)
				{
					await _appThemeService.DeleteTheme(Id);
				}
				return RedirectToAction("HomeTheme");
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}