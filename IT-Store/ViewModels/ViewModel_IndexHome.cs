using IT_Store.Models;

namespace IT_Store.ViewModels
{
	public class ViewModel_IndexHome
	{
		public ViewModel_IndexHome(IEnumerable<Product> newProducts)
		{
			NewProducts = newProducts;
		}

		public IEnumerable<Product> NewProducts { get; set; }
	}
}
