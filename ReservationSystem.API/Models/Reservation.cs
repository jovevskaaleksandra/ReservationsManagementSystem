using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateOnly Reservationday { get; set; }

    public int? Userid { get; set; }

    public virtual ICollection<DeskReservation> DeskReservations { get; set; } = new List<DeskReservation>();

    public virtual ICollection<ParkingReservation> ParkingReservations { get; set; } = new List<ParkingReservation>();

    public virtual User? User { get; set; }
}
