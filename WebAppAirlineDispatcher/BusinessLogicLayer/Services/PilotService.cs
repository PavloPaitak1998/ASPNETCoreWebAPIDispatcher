using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PilotService : IEntityService<PilotDTO>
    {
        IUnitOfWork unitOfWork;

        public PilotService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public PilotDTO GetEntity(int id)
        {
            var pilot = unitOfWork.Pilots.Get(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            return new PilotDTO
            {
                Id = pilot.Id,
                FirstName = pilot.FirstName,
                LastName = pilot.LastName,
                BirthDate = pilot.BirthDate,
                Experience = pilot.Experience
            };
        }

        public IEnumerable<PilotDTO> GetEntities()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pilot, PilotDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Pilot>, List<PilotDTO>>(unitOfWork.Pilots.GetAll());
        }

        public void CreateEntity(PilotDTO pilotDTO)
        {
            if (unitOfWork.Pilots.Get(pilotDTO.Id) != null)
            {
                throw new ValidationException($"Pilot with this id {pilotDTO.Id} already exist");
            }


            Pilot pilot = new Pilot
            {
                Id=pilotDTO.Id,
                FirstName= pilotDTO.FirstName,
                LastName=pilotDTO.LastName,
                BirthDate=pilotDTO.BirthDate,
                Experience=pilotDTO.Experience.Value
            };

            unitOfWork.Pilots.Create(pilot);
        }

        public void UpdateEntity(PilotDTO pilotDTO)
        {
            var pilot = unitOfWork.Pilots.Get(pilotDTO.Id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {pilotDTO.Id} not found");

            unitOfWork.Pilots.Update(new Pilot
            {
                Id = pilotDTO.Id,
                FirstName = pilotDTO.FirstName,
                LastName = pilotDTO.LastName,
                BirthDate = pilotDTO.BirthDate,
                Experience = pilotDTO.Experience.Value
            });
        }

        public void DeleteAllEntities()
        {
            unitOfWork.Pilots.DeleteAll();

            foreach (var crew in unitOfWork.Crew.GetAll())
            {
                crew.PilotId = 0;
            }

        }

        public void DeleteEntity(int id)
        {
            var pilot = unitOfWork.Pilots.Get(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            unitOfWork.Pilots.Delete(pilot);

            foreach (var crew in unitOfWork.Crew.Find(c => c.PilotId == id))
            {
                crew.PilotId = 0;
            }

        }
    }
}
