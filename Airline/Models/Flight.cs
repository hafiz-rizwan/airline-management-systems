using System;
using System.Collections.Generic;

namespace Airline.Models;

public partial class Flight
{
    public int FlightId { get; set; }

    public int? AirlineId { get; set; }

    public string? FlightNumber { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivalTime { get; set; }

    public virtual Airline? Airline { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
