using System;
using System.Collections.Generic;

namespace IT_Store.Models;

public partial class PaymentDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? Amount { get; set; }

    public string? Provider { get; set; }

    public string? Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Order? Order { get; set; }
}
