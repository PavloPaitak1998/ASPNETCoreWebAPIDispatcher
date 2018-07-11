using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFlightService
    {
        FlightDTO GetFlight(int id);
        IEnumerable<FlightDTO> GetFlights();
        void CreateFlight(FlightDTO flightDTO);
        void UpdateFlight(int number, FlightDTO flightDTO);
        void DeleteFlight(int id);
        void DeleteAllFlights();
    }
}
