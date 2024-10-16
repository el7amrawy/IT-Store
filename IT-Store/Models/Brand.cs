using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    [Display(Name ="Created at")]
    public DateTime CreatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool Isdeleted { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
