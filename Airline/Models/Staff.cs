using System;
using System.Collections.Generic;

namespace Airline.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Name { get; set; }

    public string? Role { get; set; }

    public int? AirlineId { get; set; }

    public string? ContactNumber { get; set; }

    public virtual Airline? Airline { get; set; }
}
