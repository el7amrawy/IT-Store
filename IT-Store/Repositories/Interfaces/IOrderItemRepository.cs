using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface IOrderItemRepository:IRepository<OrderItem>
	{
		public IEnumerable<OrderItem> GetAllByOrderId(int orderId);
	}
}
