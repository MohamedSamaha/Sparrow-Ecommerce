using SparrowManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetCartByUserId(Guid UserId);
        Task<CartDto> UpdateCart(CartDto cartDto);
        Task<CartDto> CreateCart(CartDto cartDto);
        Task DeleteCart(int Id);
        Task AddProductToCart(ProductDto productDto);

    }
}
