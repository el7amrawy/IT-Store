using IT_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
	public class ViewModel_AddProductAttribute
	{
		[Required]
		public string Name { get; set; } = null!;
		public ProductAttribute CreateProductAttribute() { 
			return new ProductAttribute { Name=Name};
		}
    }
}
