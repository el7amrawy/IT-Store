using IT_Store.Models;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		public AccountController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		//[HttpPost]
		//public IActionResult Register(ViewModel_RegisterAccount model) {
		//	if (ModelState.IsValid) {
		//		_userManager.
		//	}
		//	else
		//	{
		//		return View(model);
		//	}
		//}
	}
}
