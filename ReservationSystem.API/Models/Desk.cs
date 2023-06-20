using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Desk
{
    public int Id { get; set; }

    public int? Officeid { get; set; }

    public int? Floorid { get; set; }

    public virtual ICollection<DeskReservation> DeskReservations { get; set; } = new List<DeskReservation>();

    public virtual Floor? Floor { get; set; }

    public virtual ICollection<Hub> Hubs { get; set; } = new List<Hub>();

    public virtual ICollection<Monitor> Monitors { get; set; } = new List<Monitor>();

    public virtual Office? Office { get; set; }
}
