using System;

namespace DataAccessLayer.Models
{
    public sealed class Departure
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime Time { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}
