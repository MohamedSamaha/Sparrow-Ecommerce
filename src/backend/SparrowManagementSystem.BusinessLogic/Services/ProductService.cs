using SparrowEcommerce.Core.Entities;
using SparrowManagementSystem.BusinessLogic.Mapper;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.Mapper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Services
{
	public class ProductService : IProductService
	{
		private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
			_unitOfWork = unitOfWork;
		}

		public async Task<ProductDto> CreateProduct(ProductDto productDto)
		{
			try
			{
				// Add table that related to another when before it created.
				var material = await _unitOfWork.Materials.GetByIdAsync(productDto.MaterialId);
				var category = await _unitOfWork.Categories.GetByIdAsync(productDto.CategoryId);
				var product = new Product()
				{
					Id = productDto.Id,
					Name = productDto.Name,
					Description = productDto.Description,
					BrandName = productDto.BrandName,
					ProductCode = productDto.ProductCode,
					UnitPrice = productDto.UnitPrice,
					Size = productDto.Size,
					VendorName = productDto.VendorName,
					Color = productDto.Color,
					Rating = productDto.Rating,
					Details = productDto.Details,
					ProductCount = productDto.ProductCount,
					Discounts = productDto.Discounts,
					Material = material,
					Category = category,
					CreatedAt = productDto.CreatedAt,
					CreatedBy = productDto.CreatedBy
					
				};
				
				
				if(product != null)
				{
					await _unitOfWork.Products.CreateAsync(product);
					_unitOfWork.Save();

					
					foreach(var img in productDto.ImageDtos) 
					{
						var image = new Image();
						image.Product = product;
						image.ImageFilePath = img.ImageFilePath;
						image.ImageName = img.ImageName;
						image.CreatedAt = DateTime.Now;

						await _unitOfWork.Images.CreateAsync(image);
						_unitOfWork.Save();

					}
				}
				return productDto;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task DeleteProduct(int id)
		{
			var product = await _unitOfWork.Products.GetByIdAsync(id);
			if (product != null)
			{
				await _unitOfWork.Products.DeleteAsync(product);
				_unitOfWork.Save();
			}
		}

		public async Task<IEnumerable<ProductDto>> GetAllProducts()
		{
			try
			{
				var allProducts = await _unitOfWork.Products.EntityWithEagerLoad(p => true, new string[] { "Images", "Category", "Material" });

				/*var allProducts = await _unitOfWork.Products.GetAllAsync();*/
				var x = allProducts.Select(p => p.AsDto());
				return allProducts.Select(p => p.AsDto());

			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}

		public async Task<ProductDto> GetProductById(int id)
		{
			var product = await _unitOfWork.Products.EntityWithEagerLoad(p => p.Id == id, new string[] { "Images", "Category", "Material" });
			if(product.Count() > 0)
			{
				return product.FirstOrDefault().AsDto();
			}
			else
			{
				return null;
			}
			
		}

		public async Task<ProductDto> UpdateProduct(ProductDto productDto)
		{
			try
			{
				// Add table that related to another when before it created.
				var material = await _unitOfWork.Materials.GetByIdAsync(productDto.MaterialId);
				var category = await _unitOfWork.Categories.GetByIdAsync(productDto.CategoryId);
				var updatedProduct = await _unitOfWork.Products.GetByIdAsync(productDto.Id);
				var images = new List<ImageDto>();
				if(updatedProduct != null || productDto.ImageDtos.Count() > 0)
				{
					updatedProduct.Name = productDto.Name;
					updatedProduct.Description = productDto.Description;
					updatedProduct.BrandName = productDto.BrandName;
					updatedProduct.ProductCode = productDto.ProductCode;
					updatedProduct.UnitPrice = productDto.UnitPrice;
					updatedProduct.Size = productDto.Size;
					updatedProduct.VendorName = productDto.VendorName;
					updatedProduct.Color = productDto.Color;
					updatedProduct.Rating = productDto.Rating;
					updatedProduct.Details = productDto.Details;
					updatedProduct.ProductCount = productDto.ProductCount;
					updatedProduct.Discounts = productDto.Discounts;
					updatedProduct.Material = material;
					updatedProduct.Category = category;

					await _unitOfWork.Products.UpdateAsync(updatedProduct);
					_unitOfWork.Save();
					foreach (var img in productDto.ImageDtos)
					{
						var image = new Image();
						image.Product = await _unitOfWork.Products.GetByIdAsync(productDto.Id);
						image.ImageFilePath = img.ImageFilePath;
						image.ImageName = img.ImageName;
						image.CreatedAt = DateTime.Now;

						await _unitOfWork.Images.CreateAsync(image);
						_unitOfWork.Save();

					}
					
					
				}
				return productDto;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			
		}
		
	}
}
