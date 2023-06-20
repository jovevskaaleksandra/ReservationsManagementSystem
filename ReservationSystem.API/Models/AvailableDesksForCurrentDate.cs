using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class AvailableDesksForCurrentDate
{
    public int? Id { get; set; }

    public string? Floormap { get; set; }

    public string? Department { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public DateOnly? Date { get; set; }
}
