using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.Services;
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
		RoleManager<IdentityRole<int>> _roleManager;

        public AdminsController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
		[HttpGet]
		public async Task<IActionResult> Edit(int id) {
			User user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return this.RedirectToReferer();
			}
            var userRoles = await _userManager.GetRolesAsync(user);
			var roles= _roleManager.Roles.ToList();
			var model = new ViewModel_EditAdmin(user, userRoles.ToList(),roles);
			return View("~/Views/Admin/Admins/Edit.cshtml",model);
		}
		[HttpPost]
		public async Task<IActionResult> Edit(ViewModel_EditAdmin model, [FromServices] ICartRepository cartRepository)
		{
			if (ModelState.IsValid)
			{
				try
				{
                    var user =await _userManager.FindByIdAsync(model.Id.ToString());
					user.FirstName = model.FirstName;
					user.LastName = model.LastName;
					user.Email = model.Email;
					user.UserName = model.UserName;

                    if (model.Image != null)
                    {
                        user.Avatar = FileUpload.SaveImage(model.Image);
                    }
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (model.NewRole != null)
                        {
                            var res = await _userManager.AddToRoleAsync(user, model.NewRole);
                            if (!res.Succeeded)
                            {
                                ModelState.AddModelError("Roles", "Failed to add new role");
                            }
                        }
						return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
				catch (Exception) {
					ModelState.AddModelError("", "Failed to update the user");
				}
			}
			return View(model);
		}

		[HttpGet]
		public async Task<IActionResult> DeleteRole(string role,int userId)
		{
			User user=await _userManager.FindByIdAsync(userId.ToString());
			if (user == null) {
				return this.RedirectToReferer();
			}
			var result = await _userManager.RemoveFromRoleAsync(user, role);
			return this.RedirectToReferer();
		}
    }
}
