using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class DiscountsOffer
{
    public int Id { get; set; }

    public string TitleEn { get; set; } = null!;

    public string TitleAr { get; set; } = null!;

    public string DescriptionEn { get; set; } = null!;

    public string DescriptionAr { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public double? LimitAmount { get; set; }

    public int? LimitPersons { get; set; }

    public string Code { get; set; } = null!;

    public string? Image { get; set; }

    public int? DiscountPercentage { get; set; }

    public string? Status { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<DiscountCategory> DiscountCategories { get; set; } = new List<DiscountCategory>();
}
