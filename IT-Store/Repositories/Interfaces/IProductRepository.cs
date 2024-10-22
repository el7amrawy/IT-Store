using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface IProductRepository:IRepository<Product>
	{
		public Product GetByIdWithCategory(int id);
		public IEnumerable<Product> GetAll(int pageNumber, int pageSize = 10);
		public int GetAllCount();
		public IEnumerable<Product> GetAllWithCategory(int pageNumber = 1, int pageSize = 10);
		public IEnumerable<Product> FilterProducts( int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0, int pageNumber = 1, int pageSize = 10);
		public int FilteredProductsCount(int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0);
		public IEnumerable<Product> Search(string searchTerm, int pageNumber = 1, int pageSize = 10);

		public IEnumerable<Product> SearchAndFilter(string searchTerm, int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0, int pageNumber = 1, int pageSize = 10);
		public IEnumerable<Product> SearchAndFilter(string searchTerm,List<int> categoryIds, List<int> brandIds,int minPrice = 0, int maxPrice = 0, int pageNumber = 1, int pageSize = 10);
		public int SearchedAndFilteredCount(string searchTerm, int categoryId = 0, int minPrice = 0, int maxPrice = 0, int brandId = 0);
		public int SearchedAndFilteredCount(string searchTerm, List<int> categoryIds, List<int> brandIds, int minPrice = 0, int maxPrice = 0);
	}
}
