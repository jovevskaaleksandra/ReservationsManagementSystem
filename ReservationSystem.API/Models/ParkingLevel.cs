using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ParkingLevel
{
    public int Id { get; set; }

    public int? Level { get; set; }

    public int? Buildingid { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<ParkingSpot> ParkingSpots { get; set; } = new List<ParkingSpot>();
}
