using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Hub
{
    public int Id { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public int? Power { get; set; }

    public int? Numberofcports { get; set; }

    public int? Numberofusbports { get; set; }

    public int? Deskid { get; set; }

    public virtual Desk? Desk { get; set; }
}
