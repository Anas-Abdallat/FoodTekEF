using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class ItemOption
{
    public int OptionId { get; set; }

    public int? ItemId { get; set; }

    public string OptionNameEn { get; set; } = null!;

    public string OptionNameAr { get; set; } = null!;

    public string? Category { get; set; }

    public bool? IsRequired { get; set; }

    public DateTime? CreationDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public virtual Item? Item { get; set; }
}
