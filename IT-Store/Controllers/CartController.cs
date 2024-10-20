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
		[Route("/Cart")]
        [HttpGet]
        public IActionResult Index([FromServices] ICartItemRepository cartItemRep, [FromServices] ICartRepository cartRep)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            int userId = int.Parse(userIdClaim.Value);
            int cartId = cartRep.GetCartByUserId(userId).CartId;

            return View(cartItemRep.GetItemsByCartId(cartId));
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
				try
				{
					_cartItemRepository.Add(new CartItem { CartId = cartId, CreatedAt=dateTime, ProductId= productId , UpdatedAt=dateTime, Quantity=quantity});
					_cartItemRepository.Save();

				}
				catch (Exception ex)
				{
					ModelState.AddModelError("",ex.Message);
				}
			}
			return this.RedirectToReferer();
		}

		public IActionResult DeleteFromCart(int productId) {
			if (productId != 0)
			{
				var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
				int userId = int.Parse(userIdClaim.Value);
				int cartId = _cartRepository.GetCartByUserId(userId).CartId;

				_cartItemRepository.DeleteByCartIdAndProductId(cartId, productId);
				_cartItemRepository.Save();
			}
			return this.RedirectToReferer();
		}
	}
}
