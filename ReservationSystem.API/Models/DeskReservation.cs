using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class DeskReservation
{
    public int Id { get; set; }

    public int? Reservationid { get; set; }

    public int? Deskid { get; set; }

    public virtual Desk? Desk { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
