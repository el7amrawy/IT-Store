namespace IT_Store.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int Total { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User CartNavigation { get; set; } = null!;
}
