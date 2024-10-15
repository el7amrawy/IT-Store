using System;
using System.Collections.Generic;

namespace IT_Store.Models;

public partial class ParentCategory
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool Isdeleted { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
