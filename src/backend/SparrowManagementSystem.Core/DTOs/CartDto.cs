using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.DTOs
{
    public class CartDto : BaseDto
    {
        public decimal TotalAmount { get; set; } = 0;
        public int CartItemCount { get; set; } = 0;
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
}
