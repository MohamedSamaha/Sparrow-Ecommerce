using SparrowManagementSystem.Core.DTOs;

namespace SparrowManagementSystem.Ui.ViewModel
{
    public class HomePageCategoriesRepresentationViewModel
    {
        public IEnumerable<CategoryDto> Categories { get; set; }
        public AppThemeDto AppTheme { get; set; }
    }
}
