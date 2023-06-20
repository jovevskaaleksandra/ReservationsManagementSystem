using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ParkingSpotDetail
{
    public int? ParkingSpotId { get; set; }

    public int? Width { get; set; }

    public int? Length { get; set; }

    public int? ParkingLevelId { get; set; }

    public int? ParkingLevel { get; set; }

    public int? BuildingId { get; set; }

    public string? BuildingAddress { get; set; }
}
