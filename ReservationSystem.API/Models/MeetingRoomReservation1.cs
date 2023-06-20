using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class MeetingRoomReservation1
{
    public int? Id { get; set; }

    public string? Username { get; set; }

    public DateOnly? Reservationday { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }
}
