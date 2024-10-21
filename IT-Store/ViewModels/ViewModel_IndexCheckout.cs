using IT_Store.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IT_Store.ViewModels
{
	public class ViewModel_IndexCheckout
	{
		public List<CartItem> CartItems { get; set; }
		public SelectList Addresses { get; set; }
	}
}
