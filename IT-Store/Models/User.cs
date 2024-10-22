using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class User : IdentityUser<int>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Avatar { get; set; }
    [Display(Name ="Created At")]
    public DateTime CreatedAt { get; set; }

    public bool Isdeleted { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
