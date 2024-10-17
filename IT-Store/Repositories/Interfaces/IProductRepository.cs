using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface IProductRepository:IRepository<Product>
	{
		public Product GetByIdWithCategory(int id);
		public IEnumerable<Product> GetAllWithCategory(int pageNumber , int pageSize);
	}
}
