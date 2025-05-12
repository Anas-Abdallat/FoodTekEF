using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Rating
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ClientId { get; set; }

    public int DriverId { get; set; }

    public int? Rating1 { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual User Driver { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
