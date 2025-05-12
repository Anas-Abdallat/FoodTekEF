using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Favorite
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ItemId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual User Client { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
