namespace IT_Store.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? Id { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Landmark { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User? IdNavigation { get; set; }
}
