using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class DeskReservation1
{
    public long? Numberofreservations { get; set; }

    public string? Username { get; set; }

    public DateOnly? Reservationday { get; set; }

    public string? City { get; set; }

    public string? Companyname { get; set; }
}
