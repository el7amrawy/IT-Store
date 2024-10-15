using System;
using System.Collections.Generic;

namespace IT_Store.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? Id { get; set; }

    public int Total { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual User? IdNavigation { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}
