using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICrewService
    {
        CrewDTO GetCrew(int id);
        IEnumerable<CrewDTO> GetCrew();
        void CreateCrew(CrewDTO crewDTO);
        void UpdateCrew(CrewDTO crewDTO);
        void DeleteCrew(int id);
        void DeleteAllCrew();
    }
}
