using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class DeskMonitorDetail
{
    public int? DeskId { get; set; }

    public int? MonitorId { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public int? Size { get; set; }

    public bool? Heightadjustable { get; set; }
}
