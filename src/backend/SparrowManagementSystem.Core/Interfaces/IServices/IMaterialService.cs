using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowManagementSystem.Core.Interfaces.IServices
{
    public interface IMaterialService
    {
        Task<IEnumerable<MaterialDto>> GetAllMaterials();
        Task<MaterialDto> GetMaterialById(int Id);
        Task<MaterialDto> CreateMaterial(MaterialDto materialDto);
        Task DeleteMaterial(int Id);
        Task<MaterialDto> UpdateMaterial(MaterialDto materialDto);
    }
}
