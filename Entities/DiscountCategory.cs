using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class DiscountCategory
{
    public int Id { get; set; }

    public int? DiscountId { get; set; }

    public int? CategoryId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Category? Category { get; set; }

    public virtual DiscountsOffer? Discount { get; set; }
}
