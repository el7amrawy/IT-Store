using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface IProductRepository:IRepository<Product>
	{
		public Product GetByIdWithCategory(int id);
		public IEnumerable<Product> GetAllWithCategory(int pageNumber = 1, int pageSize = 10);
		public IEnumerable<Product> FilterProducts(int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0, int pageNumber = 1, int pageSize = 10);
		public int FilterCount(int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0);
		
	}
}
