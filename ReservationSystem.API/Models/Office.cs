using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Office
{
    public int Id { get; set; }

    public string City { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? Deparmentid { get; set; }

    public virtual Department? Deparment { get; set; }

    public virtual ICollection<Desk> Desks { get; set; } = new List<Desk>();
}
