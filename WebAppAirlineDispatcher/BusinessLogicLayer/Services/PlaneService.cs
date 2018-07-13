using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PlaneService: IPlaneService
    {
        IUnitOfWork unitOfWork;

        public PlaneService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public PlaneDTO GetPlane(int id)
        {
            var plane = unitOfWork.Planes.Get(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            return new PlaneDTO
            {
                Id = plane.Id,
                Name = plane.Name,
                TypeId = plane.TypeId,
                ReleaseDate = plane.ReleaseDate,
                Lifetime = plane.Lifetime
            };
        }

        public IEnumerable<PlaneDTO> GetPlanes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Plane, PlaneDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Plane>, List<PlaneDTO>>(unitOfWork.Planes.GetAll());
        }

        public void CreatePlane(PlaneDTO planeDTO)
        {
            if (unitOfWork.Planes.Get(planeDTO.Id) != null)
                throw new ValidationException($"Plane with this id {planeDTO.Id} already exist");

            var planeType = unitOfWork.PlaneTypes.Get(planeDTO.TypeId);
                if (planeType == null)
                    throw new ValidationException($"PlaneType with this id {planeDTO.TypeId} not found");

            Plane plane = new Plane
            {
                Id=planeDTO.Id,
                Name=planeDTO.Name,
                TypeId=planeDTO.TypeId,
                ReleaseDate=planeDTO.ReleaseDate,
                Lifetime=planeDTO.Lifetime
            };

            unitOfWork.Planes.Create(plane);
        }

        public void UpdatePlane(PlaneDTO planeDTO)
        {
            var plane = unitOfWork.Planes.Get(planeDTO.Id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {planeDTO.Id} not found");

            if (planeDTO.TypeId>0)
            {
                var planeType = unitOfWork.PlaneTypes.Get(planeDTO.TypeId);
                if (planeType == null)
                    throw new ValidationException($"PlaneType with this id {planeDTO.TypeId} not found");
            }

            unitOfWork.Planes.Update(new Plane
            {
                Id = planeDTO.Id,
                Name = planeDTO.Name,
                TypeId = planeDTO.TypeId,
                ReleaseDate = planeDTO.ReleaseDate,
                Lifetime = planeDTO.Lifetime
            });
        }

        public void DeleteAllPlanes()
        {
            unitOfWork.Planes.DeleteAll();

            foreach (var departure in unitOfWork.Departures.GetAll())
            {
                departure.PlaneId = 0;
            }

        }

        public void DeletePlane(int id)
        {
            var plane = unitOfWork.Planes.Get(id);

            if (plane == null)
                throw new ValidationException($"Plane with this id {id} not found");

            unitOfWork.Planes.Delete(plane);

            foreach (var departure in unitOfWork.Departures.Find(d => d.PlaneId == id))
            {
                departure.PlaneId = 0;
            }
        }
    }
}
