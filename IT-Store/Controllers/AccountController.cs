using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
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
		public async Task<IActionResult> Register(ViewModel_RegisterAccount model,[FromServices]ICartRepository cartRep)
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

					var createdUser=await _userManager.FindByEmailAsync(user.Email);
					if (createdUser != null)
					{
						var datetime = DateTime.Now;
						cartRep.Add(new Cart { Total = 0, CreatedAt = datetime, UserId = createdUser.Id, UpdatedAt= datetime });
						cartRep.Save();
					}

					return RedirectToAction("", "Home");
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
		[HttpGet]
		public IActionResult LogIn()
		{
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> LogIn(ViewModel_LogInAccount model)
		{
			if (ModelState.IsValid) {
				try
				{
					var user =await _userManager.FindByEmailAsync(model.Email);
					if (user == null)
					{
						throw new Exception();
					}
					else
					{
						if (await _userManager.CheckPasswordAsync(user,model.Password))
						{
							await _userManager.AddToRoleAsync(user, "User");
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
					return View(model);
				}
				
			}
			return View(model);
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("", "Home");
		}
	}
}
