using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ReservationsPerUser
{
    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? Userid { get; set; }

    public long? TotalReservations { get; set; }
}
