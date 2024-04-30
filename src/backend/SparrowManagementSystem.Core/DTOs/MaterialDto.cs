using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.DTOs
{
    public class MaterialDto : BaseDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string SupplierName { get; set; }
        public string Description { get; set; }
        public string MaterialCode { get; set; }
    }
}
