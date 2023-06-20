using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class MeetingRoomReservation
{
    public int Id { get; set; }

    public int? Reservationid { get; set; }

    public int? Meetingroomid { get; set; }

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
