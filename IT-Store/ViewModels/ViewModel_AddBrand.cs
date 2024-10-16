using IT_Store.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Store.ViewModels
{
	public class ViewModel_AddBrand
	{
		[Required]
		public string Name { get; set; } = null!;
		public string? Description { get; set; }
		[NotMapped]
		public Brand Brand { 
			get {
				var createdAt=DateTime.Now;
				return new Brand() { Name = Name, Description = Description,CreatedAt= createdAt};
			}
		}
	}
}
