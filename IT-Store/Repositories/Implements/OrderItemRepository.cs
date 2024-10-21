using IT_Store.Models;
using IT_Store.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IT_Store.Repositories.Implements
{
	public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
	{
		private readonly CodexContext _db;

		public OrderItemRepository(CodexContext db):base(db)
		{
			_db = db;
		}

		public IEnumerable<OrderItem> GetAllByOrderId(int orderId)
		{
			return _db.OrderItems.Where(x => x.OrderId == orderId).Include(o=>o.Product).ToList();
		}

		public override OrderItem GetById(int id)
		{
			return _db.OrderItems.FirstOrDefault(o=>o.ProductId==id);
		}

		public override bool IsExisted(int id)
		{
			return _db.OrderItems.Any(o=>o.ProductId == id);
		}
	}
}
