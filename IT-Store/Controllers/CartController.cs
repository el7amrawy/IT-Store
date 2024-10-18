using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IT_Store.Controllers
{
	[Authorize(Roles ="User")]
	public class CartController : Controller
	{
		private readonly ICartItemRepository _cartItemRepository;
		private readonly ICartRepository _cartRepository;

		public CartController(ICartItemRepository cartItemRepository, ICartRepository cartRepository)
		{
			_cartItemRepository = cartItemRepository;
			_cartRepository = cartRepository;
		}
		[HttpGet]
		public IActionResult AddToCart(int productId,int quantity)
		{
			if (productId != 0)
			{
				if (quantity == 0)
					quantity = 1;
				var userIdClaim=User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier);
				int userId = int.Parse(userIdClaim.Value);
				int cartId = _cartRepository.GetCartByUserId(userId).CartId;

				DateTime dateTime = DateTime.Now;

				_cartItemRepository.Add(new CartItem { CartId = cartId, CreatedAt=dateTime, ProductId= productId , UpdatedAt=dateTime, Quantity=quantity});
				_cartItemRepository.Save();
			}
			return RedirectToAction("", "Home");
		}
	}
}
