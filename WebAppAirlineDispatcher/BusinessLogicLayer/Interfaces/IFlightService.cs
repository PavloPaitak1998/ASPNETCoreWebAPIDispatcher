using Shared.DTO;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IFlightService
    {
        FlightDTO GetFlight(int? id);
        IEnumerable<FlightDTO> GetFlights();
        void AddFlight(FlightDTO flightDTO);
        IEnumerable<FlightDTO> FindFlights(Func<FlightDTO, bool> predicate);
        void CreateFlight(FlightDTO flightDTO);
        void UpdateFlight(FlightDTO flightDTO);
        void DeleteFlight(int? id);
        void DeleteAllFlights();
    }
}
