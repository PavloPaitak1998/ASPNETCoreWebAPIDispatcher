using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PlaneTypeService: IEntityService<PlaneTypeDTO>
    {
        IUnitOfWork unitOfWork;

        public PlaneTypeService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }
        public PlaneTypeDTO GetEntity(int id)
        {
            var planeType = unitOfWork.PlaneTypes.Get(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            return new PlaneTypeDTO
            {
                Id = planeType.Id,
                Model = planeType.Model,
                Seats = planeType.Seats,
                Carrying = planeType.Carrying
            };
        }

        public IEnumerable<PlaneTypeDTO> GetEntities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlaneType, PlaneTypeDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<PlaneType>, List<PlaneTypeDTO>>(unitOfWork.PlaneTypes.GetAll());
        }

        public void UpdateEntity(PlaneTypeDTO planeTypeDTO)
        {
            var planeType = unitOfWork.PlaneTypes.Get(planeTypeDTO.Id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {planeTypeDTO.Id} not found");

            unitOfWork.PlaneTypes.Update(new PlaneType
            {
                Id = planeTypeDTO.Id,
                Model = planeTypeDTO.Model,
                Seats = planeTypeDTO.Seats,
                Carrying = planeTypeDTO.Carrying
            });
        }

        public void CreateEntity(PlaneTypeDTO planeTypeDTO)
        {
            if (unitOfWork.PlaneTypes.Get(planeTypeDTO.Id) != null)
                throw new ValidationException($"Plane Type with this id {planeTypeDTO.Id} already exist");

            PlaneType planeType = new PlaneType
            {
                Id=planeTypeDTO.Id,
                Model=planeTypeDTO.Model,
                Seats= planeTypeDTO.Seats,
                Carrying= planeTypeDTO.Carrying
            };

            unitOfWork.PlaneTypes.Create(planeType);
        }

        public void DeleteAllEntities()
        {
            unitOfWork.PlaneTypes.DeleteAll();

            foreach (var plane in unitOfWork.Planes.GetAll())
            {
                plane.TypeId = 0;
            }

        }

        public void DeleteEntity(int id)
        {
            var planeType = unitOfWork.PlaneTypes.Get(id);

            if (planeType == null)
                throw new ValidationException($"Plane Type with this id {id} not found");

            unitOfWork.PlaneTypes.Delete(planeType);

            foreach (var plane in unitOfWork.Planes.Find(p => p.TypeId == id))
            {
                plane.TypeId=0;
            }
        }
    }
}
