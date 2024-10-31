using System;
using System.Collections.Generic;

namespace IT_Store.Models;

public partial class ProductsProductAttribute
{
    public int ProductId { get; set; }

    public int ProductAttributeId { get; set; }

    public string Value { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ProductAttribute ProductAttribute { get; set; } = null!;
}
