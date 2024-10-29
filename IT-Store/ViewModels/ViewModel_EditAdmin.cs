using IT_Store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
    public class ViewModel_EditAdmin
    {
        private string _newRole;
        public ViewModel_EditAdmin()
        {
            
        }
        public ViewModel_EditAdmin(User user,List<string> userRoles,List<IdentityRole<int>> roles)
        {
            var filteredRoles = roles.Where(r => !userRoles.Contains(r.Name)).ToList();
            Roles = new SelectList(filteredRoles,"Name");
            UserRoles = userRoles;
            Id=user.Id;
            FirstName=user.FirstName;
            LastName=user.LastName;
            UserName = user.UserName;
            Email = user.Email;
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
        [Display(Name = "Username")]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        public string? Avatar { get; set; }
        public IFormFile? Image { get; set; }
        [Display(Name ="Roles")]
        public List<string>? UserRoles { get; set; }
        public SelectList? Roles { get; set; }
        public string? NewRole {
            get
            {
                return _newRole;
            }
            set
            {
                if((value == "0" )|| (value?.ToLower()=="null"))
                {
                   _newRole= null;
                }
                else
                {
                    _newRole = value;
                }
            }
        }
    }
}
