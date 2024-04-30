using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Entities;
using SparrowManagementSystem.Core.Interfaces.IServices;
using System.Security.Claims;

namespace SparrowManagementSystem.Ui.Controllers
{
    [Authorize(Roles = $"{UserRole.Role_User_Admin}, {UserRole.Role_User_Customer}")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        // GET: CartController
        public async Task<ActionResult> Index()
        {
            var claims = (ClaimsIdentity)User.Identity;
            var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cartsForUser = await _cartService.GetCartByUserId(Guid.Parse(userId));

            return View(cartsForUser);
        }
		public async Task<ActionResult> Edit(int Id, decimal TotalItemPrice, int ItemProductCounter)
		{

            if (Id != null)
            {
				var cartDto = new CartDto()
                {
                    CartItemCount = ItemProductCounter,
                    Id = Id,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = 1
                };
                await _cartService.UpdateCart(cartDto);
            }
			return View();
		}
		// GET: CartController/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CartController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
        [HttpPost]
        public async Task<ActionResult> Delete(int Id)
        {
            if(Id != null)
            {
                await _cartService.DeleteCart(Id);
            }

            return RedirectToAction("Index");
        }
    }
}
