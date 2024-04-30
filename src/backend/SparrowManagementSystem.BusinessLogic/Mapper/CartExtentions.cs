using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
    public static class CartExtentions
    {
        public static CartDto AsDto(this Cart cart)
        {
            return new CartDto()
            {
                Id = cart.Id,
                CreatedAt = cart.CreatedAt,
                CreatedBy = cart.CreatedBy,
                TotalAmount = cart.TotalAmount,
                CartItemCount = cart.CartItemCount,
                ProductId = cart.ProductId,
                UserId = cart.UserId,
                Product = cart.Product.AsDto(),
                User = cart.User.AsDto(),
            };
        }
        public static Cart AsEntity(this CartDto cartDto)
        {
            return new Cart()
            {
                Id = cartDto.Id,
                CreatedAt = cartDto.CreatedAt,
                CreatedBy = cartDto.CreatedBy,
                TotalAmount = cartDto.TotalAmount,
                CartItemCount = cartDto.CartItemCount,
                ProductId = cartDto.ProductId,
                UserId = cartDto.UserId,
                Product = cartDto.Product.AsEntity(),
                User = cartDto.User.AsEntity()
            };
        }
    }
}
