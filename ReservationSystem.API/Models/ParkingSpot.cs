using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ParkingSpot
{
    public int Id { get; set; }

    public int Width { get; set; }

    public int Length { get; set; }

    public int? Parkinglevelid { get; set; }

    public virtual ICollection<ParkingReservation> ParkingReservations { get; set; } = new List<ParkingReservation>();

    public virtual ParkingLevel? Parkinglevel { get; set; }
}
