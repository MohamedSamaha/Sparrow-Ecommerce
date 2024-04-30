using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.BusinessLogic.Services;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces.IServices;

namespace SparrowManagementSystem.Ui.Controllers
{
    [Authorize(Roles = UserRole.Role_User_Admin)]
    public class MaterialController : Controller
    {

		private readonly IMaterialService _materialService;

		[BindProperty]
		public IEnumerable<MaterialDto> materials { get; set; }

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

		// GET: MaterialController
		public async Task<ActionResult> Index()
        {
			materials = await _materialService.GetAllMaterials();

			return View(materials);
		}

        // GET: MaterialController/Create
        public async Task<ActionResult> Create(string materialName, string materialType, string materialDescription, string materialCode, string supplierName)
        {
			if (materialName != null && materialType != null && materialDescription != null)
			{
                var materialDto = new MaterialDto()
                {
                    Name = materialName,
                    Type = materialType,
                    Description = materialDescription,
                    SupplierName = supplierName,
                    MaterialCode = materialCode,
                    CreatedAt = DateTime.Now,
                    CreatedBy = 1
                    
                };

				await _materialService.CreateMaterial(materialDto);
			}
			return RedirectToAction("Index");
		}

        // GET: MaterialController/Edit/5
        public async Task<ActionResult> Edit(string materialName, string materialType, string materialDescription, string materialCode, string supplierName, string Id)
        {
            try
            {
                if (Id != null)
                {
                    var materialDto = await _materialService.GetMaterialById(int.Parse(Id));

                    materialDto.Description = materialDescription;
                    materialDto.SupplierName = supplierName;
                    materialDto.MaterialCode = materialCode;
                    materialDto.Type = materialType;
                    materialDto.Name = materialName;
                    materialDto.UpdatedAt = DateTime.Now;

                    await _materialService.UpdateMaterial(materialDto);
                }
				return RedirectToAction("Index");
			}
            catch (Exception e)
            {

				throw e;
			}
			
		}

        // GET: MaterialController/Delete/5
        public async Task<ActionResult> Delete(string Id)
        {
			if (Id != null)
			{
				await _materialService.DeleteMaterial(int.Parse(Id));
			}
			return RedirectToAction("Index");
		}

        
    }
}
