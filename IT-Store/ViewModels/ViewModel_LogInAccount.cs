using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
	public class ViewModel_LogInAccount
	{
		[Required]
		[EmailAddress]
		public string Email {  get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
		public bool RememberMe { get; set; }
	}
}
