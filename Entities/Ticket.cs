using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Ticket
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Status { get; set; }

    public string? Response { get; set; }

    public string? ActionType { get; set; }

    public decimal? RefundAmount { get; set; }

    public DateOnly? RefundExpirationDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
