using IT_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
    public class ViewModel_AddProduct
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? Summary { get; set; }

        public string? Cover { get; set; }
        [Display(Name ="Serial Number")]
        public string SerialNumber { get; set; } = null!;

        public int Price { get; set; }

        public int? Discount { get; set; }
        public int Quantity { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Display(Name = "Brand")]
        public int? BrandId { get; set; }
    }
}
