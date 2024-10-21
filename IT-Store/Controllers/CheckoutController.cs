using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using IT_Store.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Store.Controllers
{
	[Authorize(Roles ="User")]
	public class CheckoutController : Controller
	{
		private readonly ICartItemRepository _cartItemRep;
		private readonly ICartRepository _cartRep;
		private readonly IAddressRepository _addressRep;
		private readonly IOrderRepository _orderRep;
		public CheckoutController(ICartItemRepository cartItemRep, ICartRepository cartRep, IAddressRepository addressRep, IOrderRepository orderRep)
		{
			_cartItemRep = cartItemRep;
			_cartRep = cartRep;
			_addressRep = addressRep;
			_orderRep = orderRep;
		}
		public IActionResult Index()
		{
			int userid=this.GetUserId();

			var cart=_cartRep.GetCartByUserId(userid);
			var cartItems = _cartItemRep.GetItemsByCartId(cart.CartId);

			var addresses=_addressRep.GetByUserId(userid);
			var model =new ViewModel_IndexCheckout { CartItems = cartItems,Addresses=new SelectList(addresses, "AddressId", "AddressLine") };
			return View(model);
		}
		[HttpPost]
		public IActionResult Order(int addressId) {
			try
			{
				int userId = this.GetUserId();
				var datetime = DateTime.Now;

				var cart = _cartRep.GetCartByUserId(userId);
				var cartItems = _cartItemRep.GetItemsByCartId(cart.CartId);
				if (cartItems.Count > 0)
				{
					int total = 0;
					foreach (var item in cartItems)
					{
						total += item.Quantity * item.Product.Price;
					}

					var order = new Order { AddressId = addressId, UserId = userId, CreatedAt = datetime, UpdatedAt = datetime, Total = total };

					foreach (var item in cartItems)
					{
						order.OrderItems.Add(new OrderItem { ProductId = item.ProductId, CreatedAt = datetime, UpdatedAt = datetime, Quantity = item.Quantity });
						_cartItemRep.Delete(item);
					}
					_orderRep.Add(order);
					_orderRep.Save();
				}
				else
				{
					//ModelState.AddModelError("","Cart is empty");
					return this.RedirectToReferer();
				}
            }
			catch (Exception ex) { 
				ModelState.AddModelError("",ex.Message);
			}
			return RedirectToAction("","Home");
		}
	}
}
