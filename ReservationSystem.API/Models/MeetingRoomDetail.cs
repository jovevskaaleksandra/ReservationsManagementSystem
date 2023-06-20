using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class MeetingRoomDetail
{
    public int? MeetingRoomId { get; set; }

    public int? Capacity { get; set; }

    public int? FloorId { get; set; }

    public int? FloorNumber { get; set; }

    public int? BuildingId { get; set; }

    public string? BuildingAddress { get; set; }
}
