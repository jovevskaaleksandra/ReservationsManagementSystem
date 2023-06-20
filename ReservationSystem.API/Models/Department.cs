using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Companyid { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Office> Offices { get; set; } = new List<Office>();
}
