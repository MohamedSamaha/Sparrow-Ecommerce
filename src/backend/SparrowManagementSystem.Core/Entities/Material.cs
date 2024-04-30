using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class Material : BaseModel
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public string MaterialCode { get; set; }

        // Navigation Properties
        public IEnumerable<Product> Products { get; set; }
    }
}
