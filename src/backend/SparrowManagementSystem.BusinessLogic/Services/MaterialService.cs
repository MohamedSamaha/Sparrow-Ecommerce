
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Interfaces;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.Mapper;

namespace SparrowManagementSystem.BusinessLogic.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaterialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<MaterialDto> CreateMaterial(MaterialDto materialDto)
        {
            if (materialDto != null)
            {
                await _unitOfWork.Materials.CreateAsync(materialDto.AsEntity());
                _unitOfWork.Save();
            }
            return materialDto;
        }

        public async Task DeleteMaterial(int Id)
        {
            var material = await _unitOfWork.Materials.GetByIdAsync(Id);
            if (material != null)
            {
                await _unitOfWork.Materials.DeleteAsync(material);
                _unitOfWork.Save();
            }
        }

        public async Task<IEnumerable<MaterialDto>> GetAllMaterials()
        {
            var allMaterials = await _unitOfWork.Materials.GetAllAsync();
            return allMaterials.Select(m => m.AsDto());
        }

        public async Task<MaterialDto> GetMaterialById(int Id)
        {
            var material = await _unitOfWork.Materials.GetByIdAsync(Id);
            return material.AsDto();
        }

        public async Task<MaterialDto> UpdateMaterial(MaterialDto materialDto)
        {
			var updatedMaterial = await _unitOfWork.Materials.GetByIdAsync(materialDto.Id);
			if (updatedMaterial != null)
			{
				updatedMaterial.Description = materialDto.Description;
				updatedMaterial.Name = materialDto.Name;
				updatedMaterial.Type = materialDto.Type;
				updatedMaterial.MaterialCode = materialDto.MaterialCode;
				updatedMaterial.SupplierName = materialDto.SupplierName;
				updatedMaterial.UpdatedAt = materialDto.UpdatedAt;
				updatedMaterial.UpdatedBy = materialDto.UpdatedBy;

				await _unitOfWork.Materials.UpdateAsync(updatedMaterial);
				_unitOfWork.Save();
			};

            return materialDto;
        }
    }
}
