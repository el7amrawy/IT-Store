using IT_Store.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Store.ViewModels
{
	public class ViewModel_RegisterAccount
	{
		[Display(Name = "First Name")]
		[Required]
		public string FirstName { get; set; } = null!;
		[Display(Name = "Last Name")]
		[Required]
		public string LastName { get; set; } = null!;
		[Required]
		public string Username {  get; set; } = null!;
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name ="Remember Me")]
		public bool RememberMe { get; set; }
		[NotMapped]
		public User User { 
			get {
				return new User { FirstName = FirstName, LastName = LastName, Email = Email, UserName = Username };
			}
		}
	}
}
