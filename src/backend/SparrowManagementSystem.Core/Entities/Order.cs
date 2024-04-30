using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class Order : BaseModel
    {
        public string? OrderNumber { get; set; }
        public decimal TotalOrderPrice { get; set; }
        public int ItemQuantity { get; set; }
        public string Email { get; set; }
        public string PhoneNumberOne { get; set; }
        public string PhoneNumberTwo { get; set; }
        public string City{ get; set; }
        public string AddressOne{ get; set; }
        public string AddressTwo{ get; set; }

        
        public IEnumerable<Product?>? Product { get; set; }
        
        public IEnumerable<Cart?>? Cart { get; set; }
        public string? TransactionStatus { get; set; }
        public bool? Paid { get; set; } = false;
        public DateTime? PaymentDate { get; set; }

    }
}
