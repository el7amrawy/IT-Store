using IT_Store.Models;

namespace IT_Store.Repositories.Interfaces
{
	public interface IBrandRepository:IRepository<Brand>
	{
		public List<Brand> GetTop(int number);
	}
}
