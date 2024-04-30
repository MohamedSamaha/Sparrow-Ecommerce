using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.ViewModel;
using System.Security.Claims;

namespace SparrowManagementSystem.Ui.Controllers
{
    
    public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly IMaterialService _materialService;
		private readonly ICategoryService _categoryService;
		private readonly IWebHostEnvironment _environment;
		private readonly IImageService _imageService;
		private readonly ICartService _cartService;

        [BindProperty]
		public List<IFormFile> productImages { get; set; }
		public ProductController(
			ICartService cartService ,
			IProductService productService,
			IWebHostEnvironment environment,
			IMaterialService materialService,
			ICategoryService categoryService,
			IImageService imageService)
        {
			_productService = productService;
			_materialService = materialService;
			_categoryService = categoryService;
			_environment = environment;
			_imageService = imageService;
			_cartService = cartService;
		}
        // GET: ProductController

        [Authorize(Roles = UserRole.Role_User_Admin)]
        public async Task<ActionResult> Index()
		{
			try
			{
				var products = await _productService.GetAllProducts();
				var allCategories = await _categoryService.GetAllCategories();
				var allMaterials = await _materialService.GetAllMaterials();

				var productViewModel = new ProductViewModel()
				{
					allCategories = allCategories,
					allMaterials = allMaterials,
					products = products
				};
				/*ViewBag.categories = allCategories;
				ViewBag.materials = allMaterials;*/
				return View(productViewModel);

			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}


        // GET: ProductController/Create
        [Authorize(Roles = UserRole.Role_User_Admin)]
        public async Task<ActionResult> Create(
			List<IFormFile> productImages,
			string productName, 
			int productCode,
			string productBrand,
			decimal productPrice,
			string productSize,
			string vendorName,
			string productColor,
			decimal productRating,
			string productDetails,
			int productCount,
			decimal productDiscount,
			string productDescription,
			int categoryId,
			int materialId)
		{
			if(productName != null || productRating <= 5)
			{
				var productImage = new List<ImageDto>();
				foreach (var ImageUpload in productImages)
				{
					if (ImageUpload != null && ImageUpload.Length > 0)
					{
						// Check if the uploaded file is an image
						if (!ImageUpload.ContentType.StartsWith("image"))
						{
							ModelState.AddModelError("Image", "Please upload a valid image file.");
							return View();
						}

						var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "SparrowImageUploads");
						var uniqueFileName = $"{Guid.NewGuid().ToString()}_{ImageUpload.FileName}";
						// file path
						var filePath = Path.Combine(uploadsFolder, uniqueFileName);

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await ImageUpload.CopyToAsync(stream);
						}

						// You can save the file path to a database or do other operations here.
						var image = new ImageDto()
						{
							ImageFilePath = filePath,
							ImageName = uniqueFileName,
						};
						productImage.Add(image);
					}
				}
				var productDto = new ProductDto()
				{
					Name = productName,
					Description = productDescription,
					BrandName = productBrand,
					ProductCode = productCode,
					UnitPrice = productPrice,
					Size = productSize,
					VendorName = vendorName,
					Color = productColor,
					Rating = productRating,
					Details = productDetails,
					ProductCount = productCount,
					Discounts = productDiscount,
					MaterialId = materialId,
					CategoryId = categoryId,
					ImageDtos = productImage,
					CreatedAt = DateTime.Now,
					CreatedBy = 1
				};

				await _productService.CreateProduct(productDto);
			}
			
			return RedirectToAction("Index");
		}


        [Authorize(Roles = UserRole.Role_User_Admin)]
        public async Task<ActionResult> Edit(List<IFormFile> productImages,
			string productName,
			int productCode,
			string productBrand,
			decimal productPrice,
			string productSize,
			string vendorName,
			string productColor,
			decimal productRating,
			string productDetails,
			int productCount,
			decimal productDiscount,
			string productDescription,
			int categoryId,
			int materialId,
			int productId)
		{
			if (productName != null || productRating <= 5)
			{
				var productImage = new List<ImageDto>();
				foreach (var ImageUpload in productImages)
				{
					if (ImageUpload != null && ImageUpload.Length > 0)
					{
						// Check if the uploaded file is an image
						if (!ImageUpload.ContentType.StartsWith("image"))
						{
							ModelState.AddModelError("Image", "Please upload a valid image file.");
							return View();
						}

						var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "SparrowImageUploads");
						var uniqueFileName = $"{Guid.NewGuid().ToString()}_{ImageUpload.FileName}";
						// file path
						var filePath = Path.Combine(uploadsFolder, uniqueFileName);

						using (var stream = new FileStream(filePath, FileMode.Create))
						{
							await ImageUpload.CopyToAsync(stream);
						}

						// You can save the file path to a database or do other operations here.
						var image = new ImageDto()
						{
							ImageFilePath = filePath,
							ImageName = uniqueFileName,
						};
						productImage.Add(image);
					}
				}
				var productDto = new ProductDto()
				{
					Id = productId,
					Name = productName,
					Description = productDescription,
					BrandName = productBrand,
					ProductCode = productCode,
					UnitPrice = productPrice,
					Size = productSize,
					VendorName = vendorName,
					Color = productColor,
					Rating = productRating,
					Details = productDetails,
					ProductCount = productCount,
					Discounts = productDiscount,
					MaterialId = materialId,
					CategoryId = categoryId,
					ImageDtos = productImage,
					CreatedAt = DateTime.Now,
					CreatedBy = 1
				};

				await _productService.UpdateProduct(productDto);
			}

			return RedirectToAction("Index");
		}

        // GET: ProductController/Delete/5
        [Authorize(Roles = UserRole.Role_User_Admin)]
        public async Task<ActionResult> Delete(int Id)
		{
			if (Id != null)
			{
				await _productService.DeleteProduct(Id);
			}
			return RedirectToAction("Index");
		}

		public async Task<ActionResult> Details(int Id)
		{
			var product = await _productService.GetProductById(Id);
			if (product == null) 
			{
				// Error Page
				return NotFound();
			}
			var productDetailsVM = new ProductDetailsViewModel()
			{
				Product = product,
                Category = await _categoryService.GetCategoryById(product.CategoryId),
                Material = await _materialService.GetMaterialById(product.MaterialId)
			};
			return View(productDetailsVM);
		}

        [Authorize(Roles = UserRole.Role_User_Admin)]
        public async Task AddProductToCart(int Id, int ItemCount, decimal ItemPrice)
		{
            var claims = (ClaimsIdentity)User.Identity;
            var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

			var cartDto = new CartDto()
			{
				CreatedAt = DateTime.Now,
				CreatedBy = 1,
				CartItemCount = ItemCount,
				ProductId = Id,
				TotalAmount = ItemPrice * ItemCount,
				UserId = userId
			};
			await _cartService.CreateCart(cartDto);
        }
    }
}
