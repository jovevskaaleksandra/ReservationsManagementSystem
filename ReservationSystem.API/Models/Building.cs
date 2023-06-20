using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Building
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<Floor> Floors { get; set; } = new List<Floor>();

    public virtual ICollection<ParkingLevel> ParkingLevels { get; set; } = new List<ParkingLevel>();
}
