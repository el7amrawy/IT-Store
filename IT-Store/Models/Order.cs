﻿using System.ComponentModel.DataAnnotations;

namespace IT_Store.Models;

public partial class Order
{
	[Display(Name ="Order Id")]
	public int OrderId { get; set; }

	public int? UserId { get; set; }

	public int AddressId { get; set; }

	public int Total { get; set; }
	[Display(Name ="Created at")]
	public DateTime CreatedAt { get; set; }

	public DateTime UpdatedAt { get; set; }

	public bool Isdeleted { get; set; }

	public virtual Address Address { get; set; } = null!;

	public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

	public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();

	public virtual User? User { get; set; }
}
