using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface ICartItemRepository:IRepository<CartItem>
	{
		public List<CartItem> GetItemsByCartId(int cartId);
		public void DeleteByCartIdAndProductId(int cartId, int productId);
		public CartItem GetByCartIdAndProductId(int cartId, int productId);
	}
}
