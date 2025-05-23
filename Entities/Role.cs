﻿using System;
using System.Collections.Generic;

namespace FoodTekEF.Entities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? RoleNameEn { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
