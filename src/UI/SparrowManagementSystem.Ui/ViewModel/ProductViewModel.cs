using SparrowManagementSystem.Core.DTOs;

namespace SparrowManagementSystem.Ui.ViewModel
{
	public class ProductViewModel
	{
        public IEnumerable<CategoryDto> allCategories { get; set; }
        public IEnumerable<MaterialDto> allMaterials { get; set; }
        public IEnumerable<ProductDto> products { get; set; }
    }
}
