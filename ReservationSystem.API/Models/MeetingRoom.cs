using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class MeetingRoom
{
    public int Id { get; set; }

    public int Capacity { get; set; }

    public int? Floorid { get; set; }

    public virtual Floor? Floor { get; set; }

    public virtual ICollection<Tv> Tvs { get; set; } = new List<Tv>();
}
