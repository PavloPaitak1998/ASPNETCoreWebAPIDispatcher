using System;

namespace Shared.DTO
{
    public sealed class FlightDTO
    {
        public int Number { get; set; }
        public string PointOfDeparture { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public int TicketId { get; set; }
    }
}
