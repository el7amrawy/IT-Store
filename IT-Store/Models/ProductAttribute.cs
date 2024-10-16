namespace IT_Store.Models;

public partial class ProductAttribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
