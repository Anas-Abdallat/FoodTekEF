using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int CartId { get; set; }

    public int ItemId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public decimal? FinalPrice { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
