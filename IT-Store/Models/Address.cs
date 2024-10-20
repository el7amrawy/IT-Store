namespace IT_Store.Models;

public partial class Address
{
	public int AddressId { get; set; }

	public int? UserId { get; set; }

	public string AddressLine { get; set; } = null!;

	public string City { get; set; } = null!;

	public string Country { get; set; } = null!;

	public string? Landmark { get; set; }

	public string PhoneNumber { get; set; } = null!;

	public DateTime CreatedAt { get; set; }

	public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

	public virtual User? User { get; set; }
}
