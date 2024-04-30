using AutoMapper;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDto> CreateOrder(OrderDto orderDto)
        {
            try
            {
                if (orderDto != null)
                {
                    var order = _mapper.Map<Order>(orderDto);
                    await _unitOfWork.Orders.CreateAsync(order);
                    _unitOfWork.Save();
                }
                return orderDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task DeleteOrder(int Id)
        {
            try
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(Id);
                if (order != null)
                {
                    await _unitOfWork.Orders.DeleteAsync(order);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<OrderDto>> getAllOrders()
        {
            try
            {
                var allOrders = await _unitOfWork.Orders.EntityWithEagerLoad(o => true, new string[] { "Product", "Cart" });
                return allOrders.Select(o => o.AsDto());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<OrderDto> GetOrderById(int Id)
        {
            try
            {
                var order = await _unitOfWork.Orders.EntityWithEagerLoad(o => o.Id == Id, new string[] { "Product", "Cart" });
                return order.FirstOrDefault().AsDto();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<OrderDto> UpdateOrder(OrderDto orderDto)
        {
            try
            {
                if (orderDto != null)
                {
                    await _unitOfWork.Orders.UpdateAsync(orderDto.AsEntity());
                    _unitOfWork.Save();

                }
                return orderDto;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
