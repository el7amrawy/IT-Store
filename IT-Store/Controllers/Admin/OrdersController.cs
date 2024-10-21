using IT_Store.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}/{id?}")]
	[Authorize(Roles = "Admin")]
	public class OrdersController : Controller
	{
		private readonly IOrderRepository _orderRep;

		public OrdersController(IOrderRepository orderRep)
		{
			_orderRep = orderRep;
		}

		public IActionResult Index()
		{
			TempData["AdminTabs"] = AdminTabs.Orders.ToString();
			return View("~/Views/Admin/Orders/Index.cshtml", _orderRep.GetAll());
		}
	}
}
