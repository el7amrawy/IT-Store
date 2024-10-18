using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public class CartRepository : Repository<Cart>, ICartRepository
	{
		private readonly CodexContext _db;

		public CartRepository(CodexContext db):base(db)
		{
			_db = db;
		}

		public override Cart GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Cart is not found");
			return _db.Carts.FirstOrDefault(c => c.CartId == id);
		}

		public override bool IsExisted(int id)
		{
			return _db.Carts.Any(c => c.CartId == id);
		}
	}
}
