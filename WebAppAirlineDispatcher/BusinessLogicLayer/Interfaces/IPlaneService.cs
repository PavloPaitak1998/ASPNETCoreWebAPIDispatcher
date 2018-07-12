using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneService
    {
        PlaneDTO GetPlane(int id);
        IEnumerable<PlaneDTO> GetPlanes();
        void CreatePlane(PlaneDTO planeDTO);
        void UpdatePlane(PlaneDTO planeDTO);
        void DeletePlane(int id);
        void DeleteAllPlanes();
    }
}
