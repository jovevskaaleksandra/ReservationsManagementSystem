using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Floor
{
    public int Id { get; set; }

    public string Floormap { get; set; } = null!;

    public int Number { get; set; }

    public int? Buildingid { get; set; }

    public virtual Building? Building { get; set; }

    public virtual ICollection<Desk> Desks { get; set; } = new List<Desk>();

    public virtual ICollection<MeetingRoom> MeetingRooms { get; set; } = new List<MeetingRoom>();
}
