﻿using System;
using System.Collections.Generic;

namespace AirlineManagement.Models ;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int? FlightId { get; set; }

    public int? PassengerId { get; set; }

    public string? SeatNumber { get; set; }

    public decimal? Price { get; set; }

    public string? Status { get; set; }

    public virtual Flight? Flight { get; set; }

    public virtual Passenger? Passenger { get; set; }
}
