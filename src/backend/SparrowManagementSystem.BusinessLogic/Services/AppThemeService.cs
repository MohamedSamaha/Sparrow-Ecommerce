using SparrowManagementSystem.BusinessLogic.Mapper;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Services
{
	public class AppThemeService : IAppThemeService
	{
		private readonly IUnitOfWork _unitOfWork;
        public AppThemeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AppThemeDto> CreateAppTheme(AppThemeDto appThemeDto)
		{
			try
			{
				if(appThemeDto != null)
				{
					var appTheme = await _unitOfWork.AppThemes.GetByIdAsync(appThemeDto.Id);
					if(appTheme == null)
					{
						await _unitOfWork.AppThemes.CreateAsync(appThemeDto.AsEntity());
						_unitOfWork.Save();
					}
				}
				return appThemeDto;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task DeleteTheme(int ThemeId)
		{
			var theme = await _unitOfWork.AppThemes.GetByIdAsync(ThemeId);
			if (theme != null)
			{
				await _unitOfWork.AppThemes.DeleteAsync(theme);
				_unitOfWork.Save();
			}
		}

		public async Task<IEnumerable<AppThemeDto>> GetAllAppThemes()
		{
			try
			{
				var allAppThemes = await _unitOfWork.AppThemes.GetAllAsync();
				return allAppThemes.Select(at => at.AsDto());
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<AppThemeDto> GetAppThemesById(int Id)
		{
			try
			{
				var actualAppTheme = await _unitOfWork.AppThemes.GetByIdAsync(Id);
				return actualAppTheme.AsDto();
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task<AppThemeDto> GetTheCurrentTheme()
		{
			var theme = await _unitOfWork.AppThemes.GetAllAsync();
			var currentTheme = theme.Where(t => t.setState == true);
			return currentTheme.FirstOrDefault().AsDto();
		}

		public async Task SetTheme(bool isThemeSet)
		{
			if (isThemeSet)
			{
				var appThemes = await _unitOfWork.AppThemes.GetAllAsync();
				if(appThemes.Count() > 0)
				{
					foreach (var item in appThemes)
					{
						item.setState = false;
						_unitOfWork.Save();
					}
				}
				
			}


		}

		public async Task<AppThemeDto> UpdateAppTheme(AppThemeDto appThemeDto)
		{
			try
			{
				var updatedAppTheme = await _unitOfWork.AppThemes.GetByIdAsync(appThemeDto.Id);
				if (updatedAppTheme != null)
				{
					await _unitOfWork.AppThemes.UpdateAsync(appThemeDto.AsEntity());
					_unitOfWork.Save();
				}
				return appThemeDto;
			}
			catch (Exception ex)
			{

				throw ex;
			}
		}

		public async Task UpdateSetTheme(int updatedThemeId)
		{
			if (updatedThemeId != null)
			{
				var actualTheme = await _unitOfWork.AppThemes.GetByIdAsync(updatedThemeId);
				actualTheme.setState = true;
				await _unitOfWork.AppThemes.UpdateAsync(actualTheme);
				_unitOfWork.Save();
			}
		}
	}
}
