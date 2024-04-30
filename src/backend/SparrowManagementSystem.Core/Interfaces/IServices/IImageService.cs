using SparrowManagementSystem.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
	public interface IImageService
	{
		Task<IEnumerable<ImageDto>> GetAllImagesWithId(int Id);
	}
}
