using System;
using System.Collections.Generic;
using AirlineManagement.Models;

namespace Airline.Models;

public partial class Airline
{
    public int AirlineId { get; set; }

    public string? AirlineName { get; set; }

    public string? Country { get; set; }

    public string? ContactNumber { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
