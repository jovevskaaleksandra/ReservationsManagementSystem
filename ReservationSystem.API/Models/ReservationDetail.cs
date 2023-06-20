using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class ReservationDetail
{
    public int? ReservationId { get; set; }

    public DateOnly? Reservationday { get; set; }

    public string? Username { get; set; }

    public int? MeetingRoomId { get; set; }

    public int? Capacity { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }
}
