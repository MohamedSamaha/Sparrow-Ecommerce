using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.DTOs
{
	public class AppThemeDto : BaseDto
	{
		public string NavBarColor { get; set; }
		public string NavBarLogoFilePath { get; set; }
		public string NavBarLogoFileName { get; set; }
		public string HomePageImageFilePath { get; set; }
		public string HomePageImageName { get; set; }
		public string SubTitle { get; set; }
		public string Title { get; set; }
		public string MainTitle { get; set; }
		public string HighLight { get; set; }
        public bool setState { get; set; } = false;
    }
}
