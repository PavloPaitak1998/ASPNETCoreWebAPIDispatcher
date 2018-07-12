using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPilotService
    {
        PilotDTO GetPilot(int id);
        IEnumerable<PilotDTO> GetPilots();
        void CreatePilot(PilotDTO pilotDTO);
        void UpdatePilot(PilotDTO pilotDTO);
        void DeletePilot(int id);
        void DeleteAllPilots();

    }
}
