using SparrowManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
	public interface IAppThemeService
	{
		Task<IEnumerable<AppThemeDto>> GetAllAppThemes();
		Task<AppThemeDto> GetAppThemesById(int Id);
		Task<AppThemeDto> UpdateAppTheme(AppThemeDto appThemeDto);
		Task<AppThemeDto> CreateAppTheme(AppThemeDto appThemeDto);
		Task SetTheme(bool isThemeSet);
		Task UpdateSetTheme(int updatedThemeId);
		Task DeleteTheme(int ThemeId);
		Task<AppThemeDto> GetTheCurrentTheme();
		
	}
}
