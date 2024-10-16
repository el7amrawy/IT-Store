using IT_Store.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Store.ViewModels
{
    public class ViewModel_AddCategory
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Display(Name ="Parent Category")]
        public int? ParentCategoryId { get; set; }
        [NotMapped]
        public Category Category { 
            get { 
                var date = DateTime.Now;
                return new Category { Name = Name,Description=Description ,CreatedAt=date,ParentCategoryId=ParentCategoryId};
            } 
        }
    }
}
