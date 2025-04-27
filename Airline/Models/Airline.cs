using System;
using System.Collections.Generic;
using AirlineManagement.Models;

namespace AirlineManagement.Models
{
    public class Airline
    {
        public int AirlineId { get; set; }
        public required string AirlineName { get; set; }
        public required string Country { get; set; }
        public required string ContactNumber { get; set; }

        // Navigation properties
        public ICollection<Flight> Flights { get; set; } = new List<Flight>();
        public ICollection<Staff> Staff { get; set; } = new List<Staff>();
    }
}
