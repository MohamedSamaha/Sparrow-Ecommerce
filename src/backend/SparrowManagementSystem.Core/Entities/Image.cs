using SparrowEcommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Entities
{
    public class Image : BaseModel
    {
        public string ImageName { get; set; }
        public string ImageFilePath { get; set; }
        public Product Product { get; set; }
    }
}
