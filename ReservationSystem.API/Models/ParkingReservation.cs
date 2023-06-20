using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ParkingReservation
{
    public int Id { get; set; }

    public int? Reservationid { get; set; }

    public int? Parkingspotid { get; set; }

    public virtual ParkingSpot? Parkingspot { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
