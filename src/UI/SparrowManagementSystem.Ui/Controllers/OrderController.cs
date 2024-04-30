using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SparrowManagementSystem.Core.DTOs;
using SparrowManagementSystem.Core.Interfaces.IServices;
using SparrowManagementSystem.Ui.ViewModel;
using System.Security.Claims;

namespace SparrowManagementSystem.Ui.Controllers
{
    public class OrderController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;
        public decimal TotalOrderAmount { get; set; } = 0;
        public int OrderItemCount { get; set; } = 0;
		public OrderController(ICartService cartService, IOrderService orderService, ICategoryService categoryService)
		{
			_cartService = cartService;
			_orderService = orderService;
			_categoryService = categoryService;
		}
		// GET: OrderController
		public async Task<ActionResult> Index()
        {
            var allOrders = await _orderService.getAllOrders();
            var allCategory = await _categoryService.GetAllCategories();
            return View(allCategory);
            
        }
        public async Task<ActionResult> OrderInfo()
        {
            var orders = await _orderService.getAllOrders();
            var claims = (ClaimsIdentity)User.Identity;
            var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

            var userCarts = await _cartService.GetCartByUserId(Guid.Parse(userId));

            var orderViewModel = new OrderViewModel()
            {
                Firstame = userCarts.FirstOrDefault().User.FirstName,
                Lastname = userCarts.FirstOrDefault().User.LastName,
                DateOfBirth = userCarts.FirstOrDefault().User.DateOfBirth,
                Gender = userCarts.FirstOrDefault().User.Gender,
                Email = claims.Name

            };
            return View(orderViewModel);

        }
        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

		// GET: OrderController/Create
		[HttpPost]
		public async Task<ActionResult> Create(string city, string phoneNomOne, string phoneNomTwo, string addressOne, string addressTwo)
        {
			try
			{
				var claims = (ClaimsIdentity)User.Identity;
				var userId = claims.FindFirst(ClaimTypes.NameIdentifier).Value;

				var userCarts = await _cartService.GetCartByUserId(Guid.Parse(userId));
                if (userCarts.Count() > 0)
                {
                    foreach(var cart in userCarts)
                    {
                        TotalOrderAmount += cart.TotalAmount;
                        OrderItemCount += cart.CartItemCount;
                    }
                    // create oderDto and give it to the Create function to create the order.
                    var orderDto = new OrderDto()
                    {
                        OrderNumber = "1",
                        TotalOrderPrice = TotalOrderAmount,
                        ItemQuantity = OrderItemCount,
                        Email = claims.Name,
                        PhoneNumberOne = phoneNomOne,
                        PhoneNumberTwo = phoneNomTwo,
                        AddressOne = addressOne,
                        AddressTwo = addressTwo,
                        City = city,
                        CartDto = userCarts

                        
                    };
                    await _orderService.CreateOrder(orderDto);
                    ViewBag.ShowSweetAlert = true;
                }
				
				return Redirect("/shop");
			}
			catch
			{
				return View();
			}
        }

        

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
