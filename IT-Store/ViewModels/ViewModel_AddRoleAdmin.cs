using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Store.ViewModels
{
    public class ViewModel_AddRoleAdmin
    {
        [Display(Name ="Add Role")]
        public string Name { get; set; }
        [NotMapped]
        public IdentityRole<int> Role { get { return new IdentityRole<int> { Name = Name }; } }
    }
}
