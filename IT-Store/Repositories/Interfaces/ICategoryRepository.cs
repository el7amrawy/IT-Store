using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface ICategoryRepository:IRepository<Category>
	{
		public IEnumerable<Category> GetAllWithParentCategory();
		public Category GetByIdWithParentCategory(int id);
	}
}
