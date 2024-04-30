using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class Shipper : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CompanyAddress { get; set; }

        public IEnumerable<Order> Orders { get; set; }

    }
}
