using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDepartureService
    {
        DepartureDTO GetDeparture(int id);
        IEnumerable<DepartureDTO> GetDepartures();
        void CreateDeparture(DepartureDTO departureDTO);
        void UpdateDeparture(DepartureDTO departureDTO);
        void DeleteDeparture(int id);
        void DeleteAllDepartures();

    }
}
