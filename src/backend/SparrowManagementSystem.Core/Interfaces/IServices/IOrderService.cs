using SparrowManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> getAllOrders();
        Task<OrderDto> GetOrderById(int Id);
        Task<OrderDto> CreateOrder(OrderDto orderDto);
        Task<OrderDto> UpdateOrder(OrderDto orderDto);
        Task DeleteOrder(int Id);
    }
}
