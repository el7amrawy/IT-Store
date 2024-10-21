using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Summary { get; set; }

    public string? Cover { get; set; }

    public string SerialNumber { get; set; } = null!;

    public int Price { get; set; }

    public int? Discount { get; set; }
    [Display(Name ="In Stock")]
    public bool Instock { get; set; }

    public int Quantity { get; set; }
    [Display(Name = "Category")]
    public int? CategoryId { get; set; }
    [Display(Name = "Brand")]
    public int? BrandId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Isdeleted { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }
	public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
	public virtual ICollection<ProductAttribute> ProductAttributes { get; set; } = new List<ProductAttribute>();
}
