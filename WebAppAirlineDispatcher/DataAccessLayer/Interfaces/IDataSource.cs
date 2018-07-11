using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDataSource
    {
        List<Flight> FlightList { get; set; }
        List<Ticket> TicketList { get; set; }
        List<Departure> DepartureList { get; set; }
        List<Stewardess> StewardessList { get; set; }
        List<Pilot> PilotList { get; set; }
        List<Crew> CrewList { get; set; }
        List<Plane> PlaneList { get; set; }
        List<PlaneType> PlaneTypeList { get; set; }
    }
}
