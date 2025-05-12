using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Otp
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Otpcode { get; set; } = null!;

    public string Otptype { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public bool IsUsed { get; set; }

    public int Attempts { get; set; }

    public string? DeviceInfo { get; set; }

    public string? Ipaddress { get; set; }

    public virtual User User { get; set; } = null!;
}
