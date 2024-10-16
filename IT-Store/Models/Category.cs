using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public int? ParentCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    [Display(Name ="Created at")]
    public DateTime CreatedAt { get; set; }

    public bool Isdeleted { get; set; }

    public virtual ParentCategory? ParentCategory { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
