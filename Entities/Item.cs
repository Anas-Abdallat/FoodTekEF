using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Item
{
    public int Id { get; set; }

    public string ItemNameEn { get; set; } = null!;

    public string ItemNameAr { get; set; } = null!;

    public string? ItemImage { get; set; }

    public string? ItemDescriptionEn { get; set; }

    public string? ItemDescriptionAr { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public int CounteAvailable { get; set; }

    public decimal? AvgRate { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<ItemOption> ItemOptions { get; set; } = new List<ItemOption>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
