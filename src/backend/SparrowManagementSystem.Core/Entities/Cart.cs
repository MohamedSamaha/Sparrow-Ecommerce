using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    // parent
    public class Cart : BaseModel
    {
        public decimal TotalAmount { get; set; }
        public int CartItemCount { get; set; }

        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }

        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
