using System;
using System.Collections.Generic;

namespace AirlineManagement.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public required string Name { get; set; }
        public required string Nationality { get; set; }
        public required string PassportNumber { get; set; }
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
