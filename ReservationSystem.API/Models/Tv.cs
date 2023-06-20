using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Tv
{
    public int Id { get; set; }

    public int Size { get; set; }

    public string Model { get; set; } = null!;

    public int Serialnumber { get; set; }

    public string Manufacturer { get; set; } = null!;

    public int? Meetingroomid { get; set; }

    public virtual MeetingRoom? Meetingroom { get; set; }
}
