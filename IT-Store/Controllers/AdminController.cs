using IT_Store.Models;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IT_Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;

		public AdminController(RoleManager<IdentityRole<int>> roleManager)
		{
			_roleManager = roleManager;
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
    }
}
