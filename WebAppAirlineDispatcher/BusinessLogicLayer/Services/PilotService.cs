using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;

namespace BusinessLogicLayer.Services
{
    public class PilotService : IPilotService
    {
        IUnitOfWork unitOfWork;

        public PilotService(IUnitOfWork uow)
        {
            unitOfWork = uow;
        }

        public PilotDTO GetPilot(int id)
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

        public IEnumerable<PilotDTO> GetPilots()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pilot, PilotDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Pilot>, List<PilotDTO>>(unitOfWork.Pilots.GetAll());
        }

        public void CreatePilot(PilotDTO pilotDTO)
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
                Experience=pilotDTO.Experience
            };

            unitOfWork.Pilots.Create(pilot);
        }

        public void UpdatePilot(PilotDTO pilotDTO)
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
                Experience = pilotDTO.Experience
            });
        }

        public void DeleteAllPilots()
        {
            unitOfWork.Pilots.DeleteAll();
        }

        public void DeletePilot(int id)
        {
            var pilot = unitOfWork.Pilots.Get(id);

            if (pilot == null)
                throw new ValidationException($"Pilot with this id {id} not found");

            unitOfWork.Pilots.Delete(id);
        }
    }
}
