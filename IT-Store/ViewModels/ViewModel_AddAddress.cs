using IT_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
    public class ViewModel_AddAddress
    {
        [Required]
        [Display(Name ="Address Line")]
        public string AddressLine { get; set; } = null!;
        [Required]

        public string City { get; set; } = null!;
        [Required]

        public string Country { get; set; } = null!;
        public string? Landmark { get; set; }
        [Display(Name = "Phone Number")]
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public Address CreateAddress(int userId)
        {
            var datetime= DateTime.Now;
            return new Address { UserId = userId, AddressLine = AddressLine, City = City, Country = Country, Landmark = Landmark, PhoneNumber = PhoneNumber, CreatedAt = datetime };
        }
    }
}
