using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
    public static class OrderExtentions
    {
        public static OrderDto AsDto(this Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                CreatedBy = order.CreatedBy,
                OrderNumber = order.OrderNumber,
                ItemQuantity = order.ItemQuantity,
                Email = order.Email,
                PhoneNumberOne  = order.PhoneNumberOne,
                PhoneNumberTwo = order.PhoneNumberTwo,
                City = order.City,
                AddressOne  = order.AddressOne,
                AddressTwo = order.AddressTwo,
                ProductDto = order.Product.Select(p => p.AsDto()),
                CartDto = order.Cart.Select(c => c.AsDto()),
                TransactionStatus = order.TransactionStatus,
                Paid =  order.Paid,
                PaymentDate = order.PaymentDate,

            };
        }
        public static Order AsEntity(this OrderDto orderDto )
        {
            try
            {
                return new Order()
                {
                    CreatedAt = orderDto.CreatedAt,
                    CreatedBy = orderDto.CreatedBy,
                    OrderNumber = orderDto.OrderNumber,
                    ItemQuantity = orderDto.ItemQuantity,
                    Email = orderDto.Email,
                    PhoneNumberOne = orderDto.PhoneNumberOne,
                    PhoneNumberTwo = orderDto.PhoneNumberTwo,
                    City = orderDto.City,
                    AddressOne = orderDto.AddressOne,
                    AddressTwo = orderDto.AddressTwo,
                    Cart = orderDto.CartDto.Select(c => c.AsEntity()),
                    TransactionStatus = orderDto.TransactionStatus,
                    Paid = orderDto.Paid,
                    PaymentDate = orderDto.PaymentDate,
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
