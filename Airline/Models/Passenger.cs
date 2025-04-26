using System;
using System.Collections.Generic;

namespace Airline.Models;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public string? Name { get; set; }

    public string? PassportNumber { get; set; }

    public string? Nationality { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
