using System;
using System.Collections.Generic;

namespace WebAppAirlineDispatcher.Modules
{
    public class FlightItem
    {
        public int Number { get; set; }
        public string PointOfDeparture { get; set; }
        public DateTime DepartureTime { get; set; }
        public string Destination { get; set; }
        public DateTime DestinationTime { get; set; }
        public List<int> TicketsId { get; set; }

    }
}
