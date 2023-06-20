using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Monitor
{
    public int Id { get; set; }

    public string? Model { get; set; }

    public string? Manufacturer { get; set; }

    public int? Size { get; set; }

    public bool? Heightadjustable { get; set; }

    public int? Deskid { get; set; }

    public virtual Desk? Desk { get; set; }
}
