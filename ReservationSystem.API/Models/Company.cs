using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Corporationid { get; set; }

    public virtual Corporation? Corporation { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
