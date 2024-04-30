using SparrowManagementSystem.Core.DTOs;

namespace SparrowManagementSystem.Ui.ViewModel
{
    public class ShopViewModel
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public CategoryDto Category { get; set; }
        public MaterialDto Material { get; set; }
    }
}
