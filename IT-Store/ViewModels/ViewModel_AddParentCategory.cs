using IT_Store.Models;
using System.ComponentModel.DataAnnotations;

namespace IT_Store.ViewModels
{
    public class ViewModel_AddParentCategory
	{
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ParentCategory Category { 
            get { 
                var date = DateTime.Now;
                return new ParentCategory { Name = Name,Description=Description ,CreatedAt=date};
            } 
        }
    }
}
