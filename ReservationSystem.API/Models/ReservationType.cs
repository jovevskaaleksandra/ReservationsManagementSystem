using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ReservationType
{
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Userid { get; set; }

    public int? Id { get; set; }

    public DateOnly? Reservationday { get; set; }

    public string? Type { get; set; }
}
