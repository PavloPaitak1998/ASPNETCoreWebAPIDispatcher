using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IStewardessService
    {
        StewardessDTO GetStewardess(int id);
        IEnumerable<StewardessDTO> GetStewardesses();
        void CreateStewardess(StewardessDTO stewardessDTO);
        void UpdateStewardess(StewardessDTO stewardessDTO);
        void DeleteStewardess(int id);
        void DeleteAllStewardesses();
    }
}
