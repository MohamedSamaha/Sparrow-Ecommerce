using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class CustomerContactInfo : BaseModel
    {
        public string Email { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string city { get; set; }
        public string Region { get; set; }
        public string BuildingNom { get; set; }
        public string Floor { get; set; }
        public string Apartement { get; set; }
        public string PhoneNom { get; set; }
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
    }
}
