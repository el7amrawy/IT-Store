using IT_Store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers.Admin
{
	[Authorize(Roles ="Admin")]
	[Route("Admin/[controller]/{action=Index}/{id?}")]
	public class UsersController : Controller
	{
		private readonly UserManager<User> _userManager;

		public UsersController(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			TempData["AdminTabs"] = AdminTabs.Users.ToString();
			return View("~/Views/Admin/Users/Index.cshtml",await _userManager.GetUsersInRoleAsync("User"));
		}
	}
}
