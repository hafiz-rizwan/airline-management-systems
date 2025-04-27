using System;
using System.Collections.Generic;

namespace AirlineManagement.Models 
{
    public class Flight
    {
        public int FlightId { get; set; }
        public required string FlightNumber { get; set; } // Added 'required'
        public required string Origin { get; set; } // Added 'required'
        public required string Destination { get; set; } // Added 'required'
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AirlineId { get; set; }
        public required Airline Airline { get; set; } // Added 'required'
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Added Tickets property
    }
}
