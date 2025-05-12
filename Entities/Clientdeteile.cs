using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Clientdeteile
{
    public int UserId { get; set; }

    public decimal? Rate { get; set; }

    public int? OrderCount { get; set; }

    public string Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
