using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IT_Store.Repositories.Implements
{
	public class CartItemRepository : Repository<CartItem>, ICartItemRepository
	{
		private readonly CodexContext _db;

		public CartItemRepository(CodexContext db):base(db)
        {
			_db = db;
		}

		public void Delete(CartItem item)
		{
			_db.Remove(item);
		}

		public void DeleteByCartIdAndProductId(int cartId, int productId)
		{
			CartItem cartItem=GetByCartIdAndProductId(cartId, productId);
			_db.CartItems.Remove(cartItem);
		}

		public CartItem GetByCartIdAndProductId(int cartId, int productId)
		{
			return _db.CartItems.FirstOrDefault(c => c.CartId == cartId && productId == c.ProductId);
		}

		public override CartItem GetById(int cartId)
		{
			if (!IsExisted(cartId))
				throw new Exception("Cart is not found");
			return _db.CartItems.FirstOrDefault(c => c.CartId == cartId);
		}

		public List<CartItem> GetItemsByCartId(int cartId)
		{
			return _db.CartItems.Where(c=>c.CartId == cartId).Include(c=>c.Product).ToList();
		}

		public override bool IsExisted(int cartId)
		{
			return _db.CartItems.Any(c => c.CartId == cartId);
		}
	}
}
