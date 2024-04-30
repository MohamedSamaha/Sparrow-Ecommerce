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


	public class ImageService : IImageService
	{
		private readonly IUnitOfWork _unitOfWork;

        public ImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

		public async Task<IEnumerable<ImageDto>> GetAllImagesWithId(int Id)
		{
			var images = await _unitOfWork.Images.EntityWithEagerLoad(img => img.Product.Id == Id, new string[] {  });
			return images.Select(i => i.AsDto());
		}
	}
}
