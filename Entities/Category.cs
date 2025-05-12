using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string NameEn { get; set; } = null!;

    public string NameAr { get; set; } = null!;

    public string Image { get; set; } = null!;

    public int? ItemCount { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<DiscountCategory> DiscountCategories { get; set; } = new List<DiscountCategory>();

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
