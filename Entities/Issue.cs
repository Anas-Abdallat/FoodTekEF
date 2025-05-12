using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Issue
{
    public int Id { get; set; }

    public int? ClientId { get; set; }

    public string Title { get; set; } = null!;

    public string ClientFullName { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public DateTime? CreationDate { get; set; }

    public string Status { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public string UpdatedBy { get; set; } = null!;

    public DateTime? UpdatedAt { get; set; }

    public virtual User? Client { get; set; }
}
