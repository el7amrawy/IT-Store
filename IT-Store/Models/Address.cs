using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class Address
{
	[Display(Name ="Id")]
	public int AddressId { get; set; }

	public int? UserId { get; set; }
    [Display(Name = "Address Line")]
    public string AddressLine { get; set; } = null!;

	public string City { get; set; } = null!;

	public string Country { get; set; } = null!;

	public string? Landmark { get; set; }
	[Display(Name ="Phone Number")]
	public string PhoneNumber { get; set; } = null!;

	public DateTime CreatedAt { get; set; }

	public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

	public virtual User? User { get; set; }
}
