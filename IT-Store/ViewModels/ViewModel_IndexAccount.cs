using IT_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
    public class ViewModel_IndexAccount
    {
        public ViewModel_IndexAccount()
        {
            
        }
        public ViewModel_IndexAccount(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Avatar = user.Avatar;
        }
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
    }
}
