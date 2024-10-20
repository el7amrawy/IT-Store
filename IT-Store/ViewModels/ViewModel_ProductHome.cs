using IT_Store.Models;

namespace IT_Store.ViewModels
{
	public class ViewModel_ProductHome
	{
		public Product Product { get; set; }
		public IEnumerable<Product> RelatedProducts {get; set;} 
	}
}
