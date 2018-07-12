using Shared.DTO;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IPlaneTypeService
    {
        PlaneTypeDTO GetPlaneType(int id);
        IEnumerable<PlaneTypeDTO> GetPlaneTypes();
        void CreatePlaneType(PlaneTypeDTO planeTypeDTO);
        void UpdatePlaneType(PlaneTypeDTO planeTypeDTO);
        void DeletePlaneType(int id);
        void DeleteAllPlaneTypes();
    }
}
