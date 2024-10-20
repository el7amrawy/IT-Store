using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
	public class CheckoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
