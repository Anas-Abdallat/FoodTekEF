using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public int ClientId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? CartStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? PaymentMethod { get; set; }

    public string? DeliveryAddress { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual User Client { get; set; } = null!;
}
