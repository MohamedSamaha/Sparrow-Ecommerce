using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class Inventory : BaseModel
    {
        public string ProductName { get; set; }
        public int MinimumStockLevel { get; set; }
        public int MaximumStockLevel { get; set; }
        public int ProductQuantity { get; set; }
        public bool ProductAvailability { get; set; }

        // Navigation Properties
    }
}
