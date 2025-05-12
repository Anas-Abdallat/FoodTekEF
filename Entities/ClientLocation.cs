using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class ClientLocation
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public int? AddressId { get; set; }

    public string AddressName { get; set; } = null!;

    public string Province { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string? AddressHint { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }

    public virtual User? Client { get; set; }
}
