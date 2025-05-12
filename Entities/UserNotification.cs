using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class UserNotification
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? NotificationId { get; set; }

    public bool? IsRead { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Notification? Notification { get; set; }

    public virtual User? User { get; set; }
}
