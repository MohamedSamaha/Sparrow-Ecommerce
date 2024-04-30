using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.BusinessLogic.Mapper
{
	public static class AppThemeExtentions
	{
			public static AppThemeDto AsDto(this AppTheme apptheme)
			{
				return new AppThemeDto()
				{
					Id = apptheme.Id,
					CreatedAt = apptheme.CreatedAt,
					CreatedBy = apptheme.CreatedBy,
					NavBarColor = apptheme.NavBarColor,
					NavBarLogoFileName = apptheme.NavBarLogoFileName,
					NavBarLogoFilePath = apptheme.NavBarLogoFilePath,
					HomePageImageFilePath = apptheme.HomePageImageFilePath,
					HomePageImageName = apptheme.HomePageImageName,
					SubTitle = apptheme.SubTitle,
					Title = apptheme.Title,
					MainTitle = apptheme.MainTitle,
					HighLight = apptheme.HighLight,
					setState = apptheme.setState,
				};
			}
			public static AppTheme AsEntity(this AppThemeDto appThemeDto)
			{
				return new AppTheme()
				{
					Id = appThemeDto.Id,
					CreatedAt = appThemeDto.CreatedAt,
					CreatedBy = appThemeDto.CreatedBy,
					NavBarColor = appThemeDto.NavBarColor,
					NavBarLogoFileName = appThemeDto.NavBarLogoFileName,
					NavBarLogoFilePath = appThemeDto.NavBarLogoFilePath,
					HomePageImageFilePath = appThemeDto.HomePageImageFilePath,
					HomePageImageName = appThemeDto.HomePageImageName,
					SubTitle = appThemeDto.SubTitle,
					Title = appThemeDto.Title,
					MainTitle = appThemeDto.MainTitle,
					HighLight = appThemeDto.HighLight,
					setState = appThemeDto.setState
				};
			}
		
	}
}
