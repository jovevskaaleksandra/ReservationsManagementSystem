using System;
using System.Collections.Generic;

namespace ReservationSystem.API.Models;

public partial class Corporation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();
}
