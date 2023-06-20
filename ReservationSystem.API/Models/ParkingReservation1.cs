using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ParkingReservation1
{
    public string? Username { get; set; }

    public DateOnly? Reservationday { get; set; }

    public int? Level { get; set; }

    public string? Address { get; set; }
}
