using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public string? OrderStatus { get; set; }

    public int? AssignedDriverId { get; set; }

    public string? CancellationReason { get; set; }

    public decimal TotalAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public DateTime? DeliveryDate { get; set; }

    public string? DeliveryAddress { get; set; }

    public DateTime? OrderDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
