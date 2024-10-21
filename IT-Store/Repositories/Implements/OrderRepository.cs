using IT_Store.Models;
using IT_Store.Repositories.Interfaces;

namespace IT_Store.Repositories.Implements
{
	public class OrderRepository : Repository<Order>, IOrderRepository
	{
		private readonly CodexContext _db;
		public OrderRepository(CodexContext db):base(db)
		{
			_db = db;
		}
		public override Order GetById(int id)
		{
			if (!IsExisted(id))
				throw new Exception("Order is not found");
			return _db.Orders.FirstOrDefault(o => o.OrderId == id);
		}

		public override bool IsExisted(int id)
		{
			return _db.Orders.Any(o => o.OrderId == id);
		}
	}
}
