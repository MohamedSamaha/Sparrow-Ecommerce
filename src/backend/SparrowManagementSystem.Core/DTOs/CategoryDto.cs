using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.DTOs
{
    public class CategoryDto : BaseDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductDto?>? productDtos { get; set; }
    }
}
