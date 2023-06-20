﻿using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class UsersRole
{
    public int? Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? Role { get; set; }
}
