using Microsoft.DotNet.Scaffolding.Shared.Messaging;
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
		[Display(Name="Remember Me")]
		public bool RememberMe { get; set; }
	}
}
