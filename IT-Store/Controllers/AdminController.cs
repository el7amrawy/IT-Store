using IT_Store.Models;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    [Authorize(Roles ="Admin")]
	public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;

		public AdminController(RoleManager<IdentityRole<int>> roleManager, UserManager<User> userManager, SignInManager<User> signInManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult Dashboard()
        {
            TempData["AdminTabs"] = AdminTabs.Dashboard.ToString();
			return View();
        }
        [HttpGet]
        public IActionResult Roles() {
			TempData["AdminTabs"] = AdminTabs.Roles.ToString();
			return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult AddRole() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(ViewModel_AddRoleAdmin model)
        {
            if (ModelState.IsValid) {
                var result = await _roleManager.CreateAsync(model.Role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded) {
                ModelState.AddModelError("", "Failed to delete role");
            }
            return RedirectToAction("Roles");
        }

		//public IActionResult Register()
		//{
		//	return View("~/Views/Account/Register.cshtml");
		//}
		//[HttpPost]
		//public async Task<IActionResult> Register(ViewModel_RegisterAccount model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var user = model.User;
		//		var result = await _userManager.CreateAsync(user, model.Password);
		//		if (result.Succeeded)
		//		{
		//			await _userManager.AddToRoleAsync(user, "Admin");

		//			await _signInManager.SignInAsync(
		//				user,
		//				new AuthenticationProperties { IsPersistent = model.RememberMe, ExpiresUtc = DateTime.Now.AddDays(7) }
		//			);

		//			return RedirectToAction("Index", "Home");
		//		}
		//		else
		//		{
		//			foreach (var item in result.Errors)
		//			{
		//				ModelState.AddModelError("", item.Description);
		//			}
		//		}
		//	}
		//	return View("~/Views/Account/Register.cshtml");
		//}
		[HttpGet]
		public IActionResult LogIn()
		{
			return View("~/Views/Account/LogIn.cshtml");
		}
		[HttpPost]
		public async Task<IActionResult> LogIn(ViewModel_LogInAccount model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var user = await _userManager.FindByEmailAsync(model.Email);
					if (user == null)
					{
						throw new Exception();
					}
					else
					{
						if (await _userManager.CheckPasswordAsync(user, model.Password))
						{
							await _signInManager.SignInAsync(
								user,
								new AuthenticationProperties { IsPersistent = model.RememberMe, ExpiresUtc = DateTime.Now.AddDays(1) }
							);
							return RedirectToAction("", "Home");
						}
						throw new Exception();
					}
				}
				catch (Exception)
				{
					ModelState.AddModelError("Password", "Wrong email or password");
					return View("~/Views/Account/LogIn.cshtml",model);
				}

			}
			return View("~/Views/Account/LogIn.cshtml",model);
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("", "Home");
		}
	}
}
