using IT_Store.Models;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Route("Admin/{controller}/{action=Index}/{id?}")]
	[Authorize(Roles ="Admin")]
    public class AdminsController : Controller
    {
		private readonly UserManager<User> _userManager;

		public AdminsController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			TempData["AdminTabs"] = AdminTabs.Admins.ToString();

			var admins =await _userManager.GetUsersInRoleAsync("admin");
            return View("~/Views/Admin/Admins/Index.cshtml",admins);
        }
		public IActionResult AddAdmin()
		{
			return View("~/Views/Admin/Admins/AddAdmin.cshtml");
		}
		[HttpPost]
		public async Task<IActionResult> AddAdmin(ViewModel_RegisterAccount model)
		{
			if (ModelState.IsValid)
			{
				var user = model.User;
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "Admin");

					return RedirectToAction("", "Admin");
				}
				else
				{
					foreach (var item in result.Errors)
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View("~/Views/Admin/Admins/AddAdmin.cshtml");
		}
	}
}
