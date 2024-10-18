using IT_Store.Models;

namespace IT_Store.ViewModels
{
	public class ViewModel_StoreHome
	{
		public IEnumerable<Product> Products { get; set; }
		public int Count {  get; set; }
		public int PageSize { get; set; }
	}
}
