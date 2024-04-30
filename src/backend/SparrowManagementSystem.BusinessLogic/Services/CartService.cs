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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task AddProductToCart(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> CreateCart(CartDto cartDto)
        {
            try
            {
                var userId = cartDto.UserId;
                if (cartDto.Id != null)
                {
                    var shoppingCart = new Cart()
                    {
                        CartItemCount = cartDto.CartItemCount,
                        TotalAmount = cartDto.TotalAmount,
                        ProductId = cartDto.ProductId,
                        UserId = cartDto.UserId,

                    };

                    await _unitOfWork.Carts.CreateAsync(shoppingCart);
                    _unitOfWork.Save();
                }
            return cartDto;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task DeleteCart(int Id)
        {
            try
            {
                if (Id != null)
                {
                    var cart = await _unitOfWork.Carts.GetByIdAsync(Id);
                    if (cart != null)
                    {
                        await _unitOfWork.Carts.DeleteAsync(cart);
                        _unitOfWork.Save();
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async Task<IEnumerable<CartDto>> GetCartByUserId(Guid UserId)
        {
            try
            {
                if (UserId != null)
                {
                    var allProducts = await _unitOfWork.Products.EntityWithEagerLoad(p => true, new string[] { "Images", "Category", "Material" });
                    var allCarts = await _unitOfWork.Carts.EntityWithEagerLoad(c => c.UserId == UserId.ToString(), new string[] { "Product", "User" });
                    var allCartsDto = allCarts.Select(c => c.AsDto()).ToList();
                    return allCartsDto;
                }
                else
                {
                    return new List<CartDto>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartDto> UpdateCart(CartDto cartDto)
        {
            try
            {
                if (cartDto != null)
                {
					var cartData = await _unitOfWork.Carts.EntityWithEagerLoad(c => c.Id == cartDto.Id, new string[] { "Product", "User" });

                    var cart = cartData.FirstOrDefault();
                    if (cart != null)
                    {
                        cart.CartItemCount = cartDto.CartItemCount;
                        cart.TotalAmount = cartDto.CartItemCount * cart.Product.UnitPrice;
                        cart.UpdatedAt = cartDto.UpdatedAt;
                        cart.UpdatedBy = cartDto.UpdatedBy;

						await _unitOfWork.Carts.UpdateAsync(cart);
						_unitOfWork.Save();
					}

                }
                return cartDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
