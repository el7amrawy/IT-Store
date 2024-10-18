using IT_Store.Models;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(ViewModel_RegisterAccount model)
		{
			if (ModelState.IsValid)
			{
				var user=model.User;
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded) {
					await _userManager.AddToRoleAsync(user, "User");

					await _signInManager.SignInAsync(
						user,
						new AuthenticationProperties { IsPersistent = model.RememberMe, ExpiresUtc = DateTime.Now.AddDays(1) }
					);

					return RedirectToAction("Index", "Home");
				}
				else
				{
                    foreach (var item in result.Errors)
                    {
						ModelState.AddModelError("",item.Description);
                    }
                }
			}
            return View();
		}
	}
}
