using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class OrderDetails : BaseModel
    {
        public decimal UnitPrice { get; set; }
        public string Type { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public string OrderState { get; set; }
        public DateTime BillDate { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

    }
}
